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

namespace RServerViewer
{

    internal class Server : ViewModelBase
    {
        private string name;
        private string version;
        private string path;
        private List<ModelRVT> models;
        private List<Directory> directories;

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

        public List<ModelRVT> Models
        {
            get { return models; }
            set { models = value; OnPropertyChanged("Models"); }
        }
        public List<Directory> Directories
        {
            get { return directories; }
            set { directories = value; OnPropertyChanged("Directories"); }
        }


        internal void Connect()
        {
            directories = new List<Directory>()
            {
                new Directory("AR")
            };
        }

        internal XmlDictionaryReader GetResponse(
  string info
)
        {
            // Create request

            WebRequest request =
              WebRequest.Create(
                "http://" +
                name +
                path +
                info
              );
            request.Method = "GET";

            // Add the information the request needs

            request.Headers.Add("User-Name", Environment.UserName);
            request.Headers.Add("User-Machine-Name", Environment.MachineName);
            request.Headers.Add("Operation-GUID", Guid.NewGuid().ToString());

            // Read the response

            XmlDictionaryReaderQuotas quotas =
              new XmlDictionaryReaderQuotas();
            XmlDictionaryReader jsonReader =
              JsonReaderWriterFactory.CreateJsonReader(
                request.GetResponse().GetResponseStream(),
                quotas
              );

            return jsonReader;
        }
    }

}
