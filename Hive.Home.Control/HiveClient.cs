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

                        else
                        {
                            var failed = response.Content.ReadAsStringAsync().Result;
                            throw new Exception(failed);
                        }

                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public object GetDevices()
        {
            try
            {
                using (var client= new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var message = new HttpRequestMessage(HttpMethod.Get, "nodes"))
                    {
                        //var raw = JsonConvert.SerializeObject(request);
                        message.Content = null;//new StringContent(null, Encoding.UTF8, "application/vnd.alertme.zoo-6.1+json");
                        message.Headers.Accept.Clear();
                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.alertme.zoo-6.1+json"));
                        message.Headers.Add("X-Omnia-Client", "Hive Web Dashboard");
                        message.Headers.Add("X-Omnia-Access-Token", "wgXomKQ39sv58svuXIebm8phosUlPYp6");

                        var response = client.SendAsync(message).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var data = response.Content.ReadAsStringAsync().Result;

                            return data;
                        }

                        else
                        {
                            var failed = response.Content.ReadAsStringAsync().Result;
                            throw new Exception(failed);
                        }


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
