using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.ResponseCaching.Internal;
using Newtonsoft.Json;
using Sonos.Integration.Models;

namespace Sonos.Integration.Services
{
    public class SonosClient : ISonosClient
    {
        public void ConnectToSonos()
        {
            const string key = "3608847c-9729-4a98-88ab-4089d36f9407";
            var url = new Uri(string.Format(
                "https://api.sonos.com/login/v3/oauth?client_id={0}&response_code=code&state=testState&scope=playback-control-all",
                key));


            try
            {

                using (var client = new HttpClient(new HttpClientHandler()))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    //client.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                    var data = client.GetAsync(url).Result;

                    var d = client.GetStringAsync(url)?.Result;

                    var content = data.Content.ReadAsStringAsync().Result;

                    //File.WriteAllText("/Users/collinsmugarura/Tests/text.html", content);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void ConnectWithCode()
        {
            try
            {
                const string auth_code = "c7a56db7-8f4a-4d54-b7a9-c4b100187a99";
                const string redirect_uri = "http%3A%2F%2Flocalhost%3A63342%2F";
                var data = $"grant_type=authorization_code&code={auth_code}&redirect_uri={redirect_uri}";

                var post = new SonosAuth
                {
                    Code = auth_code,
                    RedirectUrl = redirect_uri,
                    GrantType = "authorization_code"

                };

                var json = JsonConvert.SerializeObject(post);

                var raw = $"grant_type=authorization_code&code={auth_code}&redirect_uri={redirect_uri}";


                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri("https://api.sonos.com");
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    /*client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded")
                        {
                            CharSet = "utf-8"
                        });*/
                    //client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });
                    //client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
                    client.DefaultRequestHeaders.Add("Authorization",
                        "Basic " +
                        "MzYwODg0N2MtOTcyOS00YTk4LTg4YWItNDA4OWQzNmY5NDA3OjRhYzViYWJmLWY1NWQtNDEzMS04YzAyLWZmMGJjZDRjMmViYg==");

                    //var postData = client.PostAsync("https://api.sonos.com/login/v3/oauth/access",
                        //new StringContent(json, Encoding.UTF8)).Result;
                    

                    //var y = postData.Content.ReadAsStringAsync().Result;


                    using (var message =
                        new HttpRequestMessage(HttpMethod.Post, "https://api.sonos.com/login/v3/oauth/access"))
                    {
                        message.Content = new StringContent(raw, Encoding.UTF8, "application/x-www-form-urlencoded");
                        //message.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        message.Headers.Accept.Clear();
                        
                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                        {
                            CharSet = "utf-8"
                        });
                        message.Headers.Add("Authorization",
                            "Basic MzYwODg0N2MtOTcyOS00YTk4LTg4YWItNDA4OWQzNmY5NDA3OjRhYzViYWJmLWY1NWQtNDEzMS04YzAyLWZmMGJjZDRjMmViYg==");

                        var headers = message.Headers;
                        var authHeader = message.Headers.Authorization;
                        var result = client.SendAsync(message).Result;

                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            var responseBody = result.Content.ReadAsStringAsync().Result;
                        }

                        var d = result.Content.ReadAsStringAsync().Result;

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<HouseHold> GetSonosHouseHolds()
        {
            const string url = "api.ws.sonos.com/control/api";

            try
            {
                using (var client= new HttpClient(new HttpClientHandler
                {
                    Credentials = null
                }))
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.BaseAddress= new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", "72f23086-3d01-4c1c-869c-679c4799ed79");


                    var data = client.GetAsync("/control/api/v1/households").Result;

                    if (!data.IsSuccessStatusCode) return null;

                    var res = data.Content.ReadAsStringAsync().Result;

                    var hh = JsonConvert.DeserializeObject<IEnumerable<HouseHold>>(res);

                    return hh;


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
