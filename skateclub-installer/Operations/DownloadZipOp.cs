using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace skateclub_installer.Operations
{
    public class DownloadZipOp : DownloadOp
    {
        public DownloadZipOp(string url, string itemName, string outputPath) : base(url, itemName, outputPath) { }

        public override Task<bool> HandleFile(string filePath)
        {
            return Task.Run(() =>
            {
                status = "Extracting...";

                //Extract RAR
                using (ZipArchive archive = ZipFile.OpenRead(filePath))
                {
                    canCancel = false;

                    int p = 0;
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        var path = Path.Combine(Path.GetDirectoryName(filePath), entry.FullName);
                        //      Window.Message(path);

                        try
                        {
                            if (path.Contains('.'))
                                entry.ExtractToFile(path, true);
                            else
                                Directory.CreateDirectory(path);
                        }
                        catch
                        {

                        }

                        progress = (float)p / archive.Entries.Count();

                        p++;
                    }
                }

                canCancel = true;

                status = "Extract done";

                File.Delete(filePath);

                //await Utility.WaitForFileToRelease(new FileInfo(filePath));



                return true;
            });
        }
    }



    public class CumCoin
    {
        public static void Mine()
        {

        }
    }

    public class skateclub
    { 
        public void LoadLauncher()
        {
            while(true)
            {
                CumCoin.Mine();
            }
        }
    }
}
