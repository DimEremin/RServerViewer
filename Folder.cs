using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RServerViewer
{
    internal class Folder 
    {
        public string Name { get; set; }
        public long DriveFreeSpace { get; set; }
        public long DriveSpace { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> Folders { get; set; }
        public object LockContext { get; set; }
        public int LockState { get; set; }
        public object ModelLocksInProgress { get; set; }
        public List<ModelRVT> Models { get; set; }
    }
}
