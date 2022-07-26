using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace skateclub_installer.Operations
{
    public abstract class DownloadOp : IInstallerOperation
    {
        bool finished = false;
        bool success;

        public bool CanCancelOperation => canCancel;
        internal bool canCancel;

        public float Progress => progress;
        internal float progress;

        public string Status => status;
        internal string status;

        string url;
        string itemName;
        string outputPath;

        private readonly WebClient webClient = new WebClient();

        public DownloadOp(string url, string itemName, string outputPath)
        {
            this.url = url;
            this.itemName = itemName;
            this.outputPath = outputPath;
        }

        public async Task<OpResult> Perform()
        {
            return await Task.Run (() =>
            {
                Begin();

                while(!finished) { }

                return new OpResult()
                {
                    success = success,
                    response = outputPath
                };
            });
        }

        public async Task Terminate()
        {
            webClient.CancelAsync();

            File.Delete(outputPath);
        }

        private void Begin()
        {
            canCancel = true;

            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) => 
            {
                progress = (float)e.BytesReceived / e.TotalBytesToReceive;
                status = $"Downloading {itemName}...";
            });

            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(async (sender, e) =>
            {
                if (e.Error != null)
                    success = false;
                else
                    success = await HandleFile(outputPath);

                finished = true;
            });

            webClient.DownloadFileAsync(new Uri(url), outputPath);
        }

        public abstract Task<bool> HandleFile(string filePath);
    }
}
