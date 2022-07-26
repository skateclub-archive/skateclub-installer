using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skateclub_installer.Screens
{
    public partial class SetupScreen : UserControl, IScreen
    {
        public SetupScreen()
        {
            InitializeComponent();
        }

        public string WindowTitle => "Setup";

        public Control ScreenControl => this;


        public async Task<bool> Close() => true;

        private void SetupScreen_Load(object sender, EventArgs e)
        {
            installPath.Text = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\skateclub";
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
             //   dialog.RootFolder = Environment.SpecialFolder.ProgramFiles;

                dialog.Description = "Select a folder where you want skateclub installed";

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    installPath.Text = dialog.SelectedPath;
                }
            }
        }

        public async void Install()
        {
            try
            {
                Directory.CreateDirectory(installPath.Text);
            }
            catch(Exception e)
            {
                Window.MessageError(e.Message);
                return;
            }

            installButton.Enabled = false;

            if (!await Utility.CheckForInternetConnection())
            {
                Window.MessageError("No internet connection");
                installButton.Enabled = true;
                return;
            }

            var installParams = new InstallerParams()
            {
                installPath = installPath.Text,
                createShortcut = shortcutBox.Checked,
                downloadDependencies = dependenciesBox.Checked
            };

            Window.SetScreen(new InstallerScreen(installParams));
        }

        private void installButton_Click(object sender, EventArgs e) => Install();

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Window.instance.Close();
        }
    }
}
