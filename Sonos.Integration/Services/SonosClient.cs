using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sonos.Integration.Services
{
    public class SonosClient : ISonosClient
    {
        public void ConnectToSonos()
        {
            const string key = "3608847c-9729-4a98-88ab-4089d36f9407";
            var url = new Uri(string.Format(
                "https://api.sonos.com/login/v3/oauth?client_id={0}&response_code=code&state=testState&scope=playback-control-all)",
                key));

            
            try
            {
                
                using (var client = new HttpClient(new HttpClientHandler()))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    //client.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded");

                    var data = client.GetAsync(url).Result;

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
    }
}
