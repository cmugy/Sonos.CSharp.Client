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
        public HouseHold GetSonosHouseHolds()
        {
            return _client.GetSonosHouseHolds();
        }

        [HttpGet, Route("api/sonos/household/{id}")]
        public InternalHouseHoldResponse GetSonosSetUp(string id)
        {
            return _client.GetSonosSetUp(id);
        }

        [HttpPost, Route("api/sonos/group/{groupId}")]
        public void PlayOnSonosGroup(string groupId)
        {
            _client.PlayOnGroup(groupId);
        }
        
    }
}