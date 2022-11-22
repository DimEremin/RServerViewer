
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RServerViewer
{
    internal class ModelRVT : ViewModelBase
    {
        public object LockContext { get; set; }
        public int LockState { get; set; }
        public object ModelLocksInProgress { get; set; }
        public int ModelSize { get; set; }
        public string Name { get; set; }
        public int ProductVersion { get; set; }
        public int SupportSize { get; set; }
        public Root History { get; set; }
        public List<Item> HistoryItems { get; set; }

        internal class Root
        {
            public string Path { get; set; }
            public List<Item> Items { get; set; }
        }

        internal class Item
        {
            public string Comment { get; set; }
            public DateTime Date { get; set; }
            public int ModelSize { get; set; }
            public int OverwrittenByHistoryNumber { get; set; }
            public int SupportSize { get; set; }
            public string User { get; set; }
            public int VersionNumber { get; set; }
        }

        internal async Task GetHistory (string path)
        {
            HttpClient httpClient = AppHttpClient.getInstance();

            History = await
                (await httpClient.GetAsync(path + "|"+ Name +"/history")).
                EnsureSuccessStatusCode().Content.
                ReadAsAsync<Root>();
            HistoryItems = History.Items;
        }



    }
}
