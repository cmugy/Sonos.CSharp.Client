using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Smart.Home.Integration.Helper
{
    public static class HttpClientHelper
    {
        public static void ConfigureClient(this HttpClient client, string baseUrl)
        {
            client.Timeout = TimeSpan.FromMinutes(1);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
            {
                CharSet = "utf-8"
            });
        }
    }
}
