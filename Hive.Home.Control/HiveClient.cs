using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Sonos.Integration.Models.Hive;

namespace Hive.Home.Control
{
    public class HiveClient : IHiveClient
    {
        private const string baseUrl = "https://api-prod.bgchprod.info:443/omnia/";

        public void ConnectToHive(HiveLoginRequest request)
        {
            try
            {
                using (var client= new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var message= new HttpRequestMessage(HttpMethod.Post, "auth/sessions"))
                    {
                        var raw = JsonConvert.SerializeObject(request);
                        message.Content= new StringContent(raw,Encoding.UTF8, "application/vnd.alertme.zoo-6.1+json");
                        message.Headers.Accept.Clear();
                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.alertme.zoo-6.1+json"));
                        message.Headers.Add("X-Omnia-Client", "Hive Web Dashboard");

                        var response = client.SendAsync(message).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var data = response.Content.ReadAsStringAsync().Result;
                        }

                        var failed = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
