using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sonos.Integration.Services
{
    public class SonosClient : ISonosClient
    {
        public void ConnectToSonos()
        {
            try
            {
                using (var client = new HttpClient(new HttpClientHandler()))
                {

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
