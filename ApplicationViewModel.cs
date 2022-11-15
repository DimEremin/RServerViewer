using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RServerViewer
{
    internal class ApplicationViewModel : ViewModelBase
    {


        private Server selectedServer;
        private Folder selectedFolder;
        private ModelRVT selectedModelRVT;
        
        public ObservableCollection<Server> Servers { get; set; }

        public Server SelectedServer
        {
            get { return selectedServer; }
            set
            {
                selectedServer = value;
                OnPropertyChanged("SelectedServer");
            }
        }
        public Folder SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;
                OnPropertyChanged("SelectedFolder");
            }
        }
        public ModelRVT SelectedModelRVT
        {
            get { return selectedModelRVT; }
            set
            {
                selectedModelRVT = value;
                OnPropertyChanged("SelectedModelRVT");
            }
        }

        private List<Folder> dirList;
        public List<Folder> DirList
        {
            get { return dirList; }
            set { dirList = value; OnPropertyChanged("DirList"); }
        }


        // команда соединения с сервером
        private RelayCommand connectCommand;
        public RelayCommand ConnectCommand
        {
            get
            {
                return connectCommand ??
                  (connectCommand = new RelayCommand(async obj =>
                  {
                      if (SelectedServer != null)
                      {
                          await SelectedServer.Connect();
                          DirList = SelectedServer.Folders;
                      }      
                  }));
            }
        }

        public ApplicationViewModel()
        {

            Servers = new ObservableCollection<Server>
            {
                new Server {Name="192.168.120.66", Version="2019"},
                new Server {Name="Rev2022", Version="2022"},
            };

        }

    }
}
