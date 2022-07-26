using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace skateclub_installer
{
    public class Utility
    {
        public static async Task<bool> CheckForInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                if(url == null)
                    url = "http://www.gstatic.com/generate_204";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;

                var response = await request.GetResponseAsync();

                if(response != null)
                    return true;
            }
            catch { }

            return false;
        }

        public static async Task WaitForFileToRelease(FileInfo file)
        {
            await Task.Run(() =>
            {
                while(IsFileLocked(file)) { }
            });
        }

        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        public static void CreateShortcut(string app, string linkName)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + $"\\{linkName}.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Launch skateclub";
            shortcut.TargetPath = app;
            shortcut.Save();
        }
    }
}
