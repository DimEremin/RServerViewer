using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RServerViewer
{
    internal class Directory : ViewModelBase
    {
        private string directoryName;
        private List<ModelRVT> models;
        private List<Directory> directories;
        public string DirectoryName

        {
            get { return directoryName; }
            set
            {
                directoryName = value;
                OnPropertyChanged("DirectoryName");
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

        public Directory(string dirName)
        {
            directoryName = dirName;
            models = new List<ModelRVT>()
            {
                new ModelRVT("sdf.rvt"),
                new ModelRVT("sf.rvt")
            };


        }

    }
}
