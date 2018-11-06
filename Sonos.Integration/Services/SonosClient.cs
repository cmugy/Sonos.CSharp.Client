using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Sonos.Integration.Models;
using Sonos.Integration.Models.Request;
using Sonos.Integration.Models.Response;
using Sonos.Integration.Models.SonosStatus;
using Sonos.Integration.Services;

namespace Smart.Home.Integration.Services
{
    public class SonosClient : ISonosClient
    {
        private const string Token = "695b0aae-823c-4877-bf47-13e20c4bf51b";

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

        public HouseHold GetSonosHouseHolds()
        {
            const string url = "https://api.ws.sonos.com/control/api/";

            try
            {
                using (var client = new HttpClient(new HttpClientHandler
                {
                    Credentials = null
                }))
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);


                    var data = client.GetAsync("v1/households").Result;

                    if (!data.IsSuccessStatusCode) return null;

                    var res = data.Content.ReadAsStringAsync().Result;

                    var hh = JsonConvert.DeserializeObject<HouseHoldResponse>(res);

                    return hh.HouseHolds.FirstOrDefault();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetNewRefreshedToken(string refreshToken)
        {
            try
            {
                var content = $"grant_type=refresh_token&refresh_token={refreshToken}";
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Add("Authorization",
                        "Basic " +
                        "MzYwODg0N2MtOTcyOS00YTk4LTg4YWItNDA4OWQzNmY5NDA3OjRhYzViYWJmLWY1NWQtNDEzMS04YzAyLWZmMGJjZDRjMmViYg==");

                    using (var message =
                        new HttpRequestMessage(HttpMethod.Post, "https://api.sonos.com/login/v3/oauth/access"))
                    {
                        message.Content =
                            new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");

                        message.Headers.Accept.Clear();

                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                        {
                            CharSet = "utf-8"
                        });

                        var response = client.SendAsync(message).Result;

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var contentData = response.Content.ReadAsStringAsync().Result;

                            var des = JsonConvert.DeserializeObject<Auth>(contentData);

                            return des.AccessToken;
                        }

                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public InternalHouseHoldResponse GetSonosSetUp(string id)
        {
            const string url = "https://api.ws.sonos.com/control/api/";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    var result = client.GetAsync($"v1/households/{id}/groups").Result;

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        var content = result.Content.ReadAsStringAsync().Result;

                        var response = JsonConvert.DeserializeObject<InternalHouseHoldResponse>(content);

                        return response;

                    }

                    else
                    {
                        return null;
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void PlayOnGroup(string groupId)
        {
            //const string url = "https://api.ws.sonos.com/control/api/";
            try
            {
                using (var client = new HttpClient())
                {


                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    //client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    //var result = client.PostAsync($"groups/{groupId}/playback:1/play", new StringContent("")).Result;



                    using (var message =
                        new HttpRequestMessage(HttpMethod.Post,
                            $"https://api.ws.sonos.com/control/api/v1/groups/{groupId}/playback:1/play")
                    )
                    {
                        //message.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                        message.Content = null;


                        message.Headers.Accept.Clear();
                        message.Headers.Clear();

                        //message.Headers.Add("Content-Length", "0");

                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                        {
                            CharSet = "utf-8"
                        });

                        var response = client.SendAsync(message).Result;

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var data = response.Content.ReadAsStringAsync().Result;

                            var headers = response.Headers;
                        }

                        var output = response.Content.ReadAsStringAsync().Result;

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int GetGroupVolume(string groupId)
        {
            const string url = "https://api.ws.sonos.com/control/api/v1/";
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    var response = client.GetAsync($"groups/{groupId}/groupVolume").Result;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        var data = JsonConvert.DeserializeObject<VolumeModel>(result);

                        return data.Volume;
                    }

                    return 0;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetGroupVolume(SetGroupVolume groupVolume)
        {
            const string baseUrl = "https://api.ws.sonos.com/control/api/v1/";
            var control = new VolumeControl
            {
                Volume = groupVolume.Volume
            };

            var json = JsonConvert.SerializeObject(control);

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    var response = client.PostAsync($"groups/{groupVolume.GroupId}/groupVolume",
                        new StringContent(json, Encoding.UTF8, "application/json")).Result;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public PlayBackStatusResponse GetPlaybackStatusResponse(string groupId)
        {
            var baseUrl = "https://api.ws.sonos.com/control/api/v1/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    var response = client.GetAsync($"groups/{groupId}/playback").Result;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        var status = JsonConvert.DeserializeObject<PlayBackStatusResponse>(result);

                        return status;
                    }

                    return null;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public GroupResponse CreateGroup(PlayerRequest request)
        {
            const string baseUrl = "https://api.ws.sonos.com/control/api/v1/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    using (var message = new HttpRequestMessage(HttpMethod.Post,
                        $"households/{request.HouseholdId}/groups/createGroup"))
                    {
                        var content = new SonosGroupRequest
                        {
                            PlayerIds = request.PlayerIds
                        };

                        var json = JsonConvert.SerializeObject(content);

                        message.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        message.Headers.Clear();
                        message.Headers.Accept.Clear();


                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                        {
                            CharSet = "utf-8"
                        });

                        var response = client.SendAsync(message).Result;

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;

                            var groupResponse = JsonConvert.DeserializeObject<GroupResponse>(result);

                            return groupResponse;
                        }

                        return null;

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SwitchPlayerToTv(string playerId)
        {
            const string baseUrl = "https://api.ws.sonos.com/control/api/v1/";

            try
            {
                using (var client = new HttpClient())
                {


                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                    {
                        CharSet = "utf-8"
                    });

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    using (var message = new HttpRequestMessage(HttpMethod.Post,
                        $"players/{playerId}/homeTheater"))
                    {
                        var content = JsonConvert.SerializeObject(new HomeTheaterRequest {PlayerId = playerId});

                        var json = JsonConvert.SerializeObject(content);

                        //message.Content = new StringContent(json, Encoding.UTF8, "application/json");
                        message.Content = null;

                        message.Headers.Clear();
                        message.Headers.Accept.Clear();


                        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
                        {
                            CharSet = "utf-8"
                        });

                        var response = client.SendAsync(message).Result;

                        var result = response.Content.ReadAsStringAsync().Result;

                        //var code = response.StatusCode;


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
