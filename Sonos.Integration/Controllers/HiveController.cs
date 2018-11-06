using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hive.Home.Control;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sonos.Integration.Models.Hive;

namespace Sonos.Integration.Controllers
{
    [Produces("application/json")]
    [Route("api/Hive")]
    public class HiveController : Controller
    {
        private readonly IHiveClient _client;

        public HiveController(IHiveClient client)
        {
            _client = client;
        }

        [HttpPost, Route("login")]
        public void Login([FromBody] HiveLoginRequest request)
        {
            _client.ConnectToHive(request);
        }

        [HttpGet, Route("devices")]
        public object GetHiveDevices()
        {
            return _client.GetDevices();
        }
    }
}