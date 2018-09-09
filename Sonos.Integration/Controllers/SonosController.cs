using Microsoft.AspNetCore.Mvc;
using Sonos.Integration.Services;

namespace Sonos.Integration.Controllers
{
    public class SonosController : Controller
    {
        private readonly ISonosClient _client;

        public SonosController(ISonosClient client)
        {
            _client = client;
        }

        [HttpGet, Route("api/sonos")]
        public object GetSonosAuthorisation()
        {
            _client.ConnectToSonos();


            return null;
        }
    }
}