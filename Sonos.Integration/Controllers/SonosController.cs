using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sonos.Integration.Models;
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
            //_client.ConnectToSonos();
            _client.ConnectWithCode();


            return null;
        }

        [HttpGet, Route("api/sonos/household")]
        public IEnumerable<HouseHold> GetSonosHouseHolds()
        {
            return _client.GetSonosHouseHolds();
        }
        
    }
}