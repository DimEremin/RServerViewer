using System.Collections.Generic;
using System.Windows;

namespace RServerViewer
{
    internal class Folder : ViewModelBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long DriveFreeSpace { get; set; }
        public long DriveSpace { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> Folders { get; set; }
        public object LockContext { get; set; }
        public int LockState { get; set; }
        public object ModelLocksInProgress { get; set; }
        public List<ModelRVT> Models { get; set; }

        private ModelRVT selectedModelRVT;

        public ModelRVT SelectedModelRVT
        {
            get { return selectedModelRVT; }
            set
            {
                selectedModelRVT = value;

                //MessageBox.Show("Model");
                selectedModelRVT.GetHistory(Path);

                OnPropertyChanged("SelectedModelRVT");
            }
        }
    }
}
