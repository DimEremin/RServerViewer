using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Reflection;
using System.Net.Http;

namespace RServerViewer
{

    internal class Server : ViewModelBase
    {

        private static Dictionary<string, string> supportedVersions = new Dictionary<string, string>()
        {
                  {"2012", "/RevitServerAdminRESTService/AdminRESTService.svc"},
                  {"2013", "/RevitServerAdminRESTService2013/AdminRESTService.svc"},
                  {"2014", "/RevitServerAdminRESTService2014/AdminRESTService.svc"},
                  {"2015", "/RevitServerAdminRESTService2015/AdminRESTService.svc"},
                  {"2016", "/RevitServerAdminRESTService2016/AdminRESTService.svc"},
                  {"2017", "/RevitServerAdminRESTService2017/AdminRESTService.svc"},
                  {"2018", "/RevitServerAdminRESTService2018/AdminRESTService.svc"},
                  {"2019", "/RevitServerAdminRESTService2019/AdminRESTService.svc"},
                  {"2020", "/RevitServerAdminRESTService2020/AdminRESTService.svc"},
                  {"2021", "/RevitServerAdminRESTService2021/AdminRESTService.svc"},
                  {"2022", "/RevitServerAdminRESTService2022/AdminRESTService.svc"},
        };

        static HttpClient httpClient;
        private string name;
        private string version;
        private string path;
        private List<Folder> folders;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Version
        {
            get { return version; }
            set
            {
                version = value;
                OnPropertyChanged("Version");
            }
        }
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        public List<Folder> Folders
        {
            get { return folders; }
            set { folders = value;  }
        }


        internal async Task Connect()
        {
            folders = new List<Folder>();

            httpClient = new HttpClient();
            //string request = "http://192.168.120.66/RevitServerAdminRESTService2019/AdminRESTService.svc/|";
            string stringRequest = "http://" + Name + supportedVersions[version] + "/|";

            httpClient.DefaultRequestHeaders.Add("User-Name", Environment.UserName);
            httpClient.DefaultRequestHeaders.Add("User-Machine-Name", Environment.MachineName);
            httpClient.DefaultRequestHeaders.Add("Operation-GUID", Guid.NewGuid().ToString());

             folders.Add((await GetAndDeserializeFolder(stringRequest)));
            folders[0].Name = "Server";
        }
        public static async Task<Folder> GetAndDeserializeFolder(string path)
        {
            Folder folder = await
                            (await httpClient.GetAsync(path + "/contents")).
                            EnsureSuccessStatusCode().Content.
                            ReadAsAsync<Folder>();

            if (folder.Folders.Count > 0)
            {
                path += "|" + folder.Name;
                List<Folder> tempFolders = new List<Folder>();

                foreach (Folder folder2 in folder.Folders)
                {
                    Folder tempFolder = await GetAndDeserializeFolder(path + folder2.Name);
                    tempFolder.Name = folder2.Name;
                    tempFolders.Add(tempFolder);
                }

                folder.Folders.Clear();
                folder.Folders.AddRange(tempFolders);
            }

            return folder;
        }


    }

}
