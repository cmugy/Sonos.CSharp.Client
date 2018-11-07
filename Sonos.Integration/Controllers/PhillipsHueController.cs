using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phillips.Hue.Control;

namespace Smart.Home.Integration.Controllers
{
    [Route("api/Hue")]
    public class PhillipsHueController : Controller
    {       
        private readonly IPhillipsHueClient _phillipsHueClient;

        public PhillipsHueController(IPhillipsHueClient _phillipsHueClient)
        {
            this._phillipsHueClient = _phillipsHueClient;
        }
        
        [HttpPost, Route("createUser")]
        public void CreateUser(string user)
        {
            this._phillipsHueClient.CreateUser(user);
        }
    }
}
