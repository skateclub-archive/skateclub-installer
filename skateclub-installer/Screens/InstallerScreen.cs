using skateclub_installer.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skateclub_installer.Screens
{
    public partial class InstallerScreen : UserControl, IScreen
    {

        public string WindowTitle => activeOperation.Status;

        public Control ScreenControl => this;

        InstallerParams installerParams;

        public IInstallerOperation activeOperation { get; private set; }

        string downloadZipPath => installerParams.installPath + "/download.zip";

        public async Task<OpResult> Run(IInstallerOperation op)
        {
            activeOperation = op;
            return await activeOperation.Perform();
        }

        public InstallerScreen(InstallerParams installerParams)
        {
            this.installerParams = installerParams;

            InitializeComponent();
        }

        public async Task<bool> Close()
        {
            if (activeOperation.CanCancelOperation)
            {
                if(Window.MessageWarning("Are you sure you want to cancel the installation?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await activeOperation.Terminate();

                    return true;
                }
            }
            else
            {
                Window.MessageWarning("The window cannot be closed at the moment.");
            }

            return false;
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            Window.UIUpdateClock.Tick += (s, a) =>
            {
                progressBar.Value = Math.Min((int)(activeOperation.Progress * 100f), 100);
                statusText.Text = $"{activeOperation.Status} {(activeOperation.Progress != 0f ? $"({(activeOperation.Progress * 100f).ToString("0.0")}%)" : "")}";
            };

            BeginOperationSequence();
        }

        public async void BeginOperationSequence()
        {
            try
            {
                var downloadDetails = (await Run(new GetDownloadDetailsOp("REMOVED"))).response as ClientDownloadDetails?;

                if (downloadDetails.HasValue)
                {
                    var clientDownloadResult = await Run(new DownloadZipOp(downloadDetails.Value.url, $"launcher (v{downloadDetails.Value.version})", downloadZipPath));

                    if (clientDownloadResult.success)
                    {
                        if (installerParams.downloadDependencies)
                        {
                            foreach(var dependency in downloadDetails.Value.dependencies)
                            {
                                string path = installerParams.installPath + "\\dep.exe";
                                var downloadDep = await Run(new DownloadExeOp(dependency.url, dependency.args, "dependencies", path));
                                File.Delete(path);
                            }
                        }

                        if(installerParams.createShortcut)
                        {
                            Utility.CreateShortcut(installerParams.installPath +"/skateclub.exe", "skateclub");
                        }

                        Finish();
                    }
                }
            } catch(Exception e)
            {
                Window.MessageError($"The installer has encountered an error.\n\n{e.Message}\n\nPlease restart the installer.");
            }

            Window.Finished();
        }

        void Finish()
        {
            if (Window.Message("The skateclub launcher has been installed! Would you like to launch it?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(installerParams.installPath + "\\skateclub.exe");
                }
                catch { }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Window.instance.Close();
        }
    }
}
