using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skateclub_installer.Operations
{
    public class DownloadExeOp : DownloadOp
    {
        string args;

        public DownloadExeOp(string url, string args, string itemName, string outputPath) : base(url, itemName, outputPath) { this.args = args; }

        public override async Task<bool> HandleFile(string filePath)
        {
            return await Task.Run(() =>
            {
                canCancel = false;

                progress = 0f;

                status = "Installing... (Accept any admin prompts you get)";

                var process = Process.Start(filePath, args);

                process.WaitForExit();

                canCancel = true;

                return process.ExitCode == 0;
            });
        }
    }
}
