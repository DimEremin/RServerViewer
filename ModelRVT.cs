using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RServerViewer
{
    internal class ModelRVT : ViewModelBase
    {
        private string modelname;
        public string ModelName
        {
            get { return modelname; }
            set
            {
                modelname = value;
                OnPropertyChanged("ModelName");
            }
        }
        public ModelRVT(string n)
        {
            modelname = n;
        }

    }
}
