using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace skateclub_installer.Operations
{
    public struct ClientDependency
    {
        public string url;
        public string args;
    }

    public struct ClientDownloadDetails
    {
        public string url;
        public string version;
        public ClientDependency[] dependencies;
    }

    public class GetDownloadDetailsOp : IInstallerOperation
    {
        public bool CanCancelOperation => false;

        public string Status => "Preparing...";

        public float Progress => 0f;

        string updateServerUrl;

        public GetDownloadDetailsOp(string updateServerUrl)
        {
            this.updateServerUrl = updateServerUrl;
        }

        public async Task<OpResult> Perform()
        {
            return await Task.Run(() =>
            {
                XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
                xmlDoc.LoadXml(new WebClient().DownloadString(new Uri(updateServerUrl))); // Load the XML document from the specified file

                var version = xmlDoc.GetElementsByTagName("version")[0].InnerText;
                var url = xmlDoc.GetElementsByTagName("url")[0].InnerText;

                ClientDependency[] dependencies = xmlDoc.GetElementsByTagName("dependency").Cast<XmlNode>().Select(x =>
                {
                    return new ClientDependency()
                    {
                        url = x.ChildNodes.Cast<XmlNode>().Where(q => q.Name == "url").ToArray()[0].InnerText,
                        args = x.ChildNodes.Cast<XmlNode>().Where(q => q.Name == "args").ToArray()[0].InnerText
                    };
                }).ToArray();

                return new OpResult()
                {
                    success = true,
                    response = new ClientDownloadDetails()
                    {
                        version = version,
                        url = url,
                        dependencies = dependencies
                    }
                };

                return new OpResult() { success = false };
            });
        }

        public async Task Terminate() { }
    }
}
