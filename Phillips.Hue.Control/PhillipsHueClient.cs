using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Sonos.Integration.Models.Hue;

namespace Phillips.Hue.Control
{
    public class PhillipsHueClient : IPhillipsHueClient
    {
        private const string _baseUrl = "http://192.168.86.102/api/";

        public void ConnectToHue()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CreateUser(string user)
        {
            var request = new CreateUserRequest
            {
                DeviceType = $"test#{user}"
            };

            try
            {
                using (var client= new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var message= new HttpRequestMessage(HttpMethod.Post, ""))
                    {
                        var serializeObject = JsonConvert.SerializeObject(request);
                        message.Content = new StringContent(serializeObject, Encoding.UTF8,
                            "application/json");
                        message.Headers.Accept.Clear();
                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = client.SendAsync(message).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var data = response.Content.ReadAsStringAsync().Result;
                        }

                        else
                        {
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
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
