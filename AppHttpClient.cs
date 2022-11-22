using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RServerViewer
{
    class AppHttpClient
    {
        private static HttpClient httpClient;

        private AppHttpClient()
        { }

        public static HttpClient getInstance()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Name", Environment.UserName);
                httpClient.DefaultRequestHeaders.Add("User-Machine-Name", Environment.MachineName);
                httpClient.DefaultRequestHeaders.Add("Operation-GUID", Guid.NewGuid().ToString());
            }

            return httpClient;
        }
    }
}
