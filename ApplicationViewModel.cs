using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows;

namespace RServerViewer
{
    internal class ApplicationViewModel : ViewModelBase
    {


        private Server selectedServer;



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

        private List<Directory> dirList;
        public List<Directory> DirList
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
                  (connectCommand = new RelayCommand(obj =>
                  {
                      if (SelectedServer != null)
                      {
                          SelectedServer.Connect();
                          DirList = SelectedServer.Directories;
                      }      
                  }));
            }
        }

        public ApplicationViewModel()
        {

            Servers = new ObservableCollection<Server>
            {
                new Server {Name="Rev2019", Version="2019", Path ="/RevitServerAdminRESTService2019/AdminRESTService.svc" },
                new Server {Name="Rev2022", Version="2022", Path ="/RevitServerAdminRESTService2022/AdminRESTService.svc" },
            };

        }

    }
}
