using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sonos.Integration.Models;

namespace Sonos.Integration.Services
{
    public interface ISonosClient
    {
        void ConnectToSonos();
        void ConnectWithCode();
        IEnumerable<HouseHold> GetSonosHouseHolds();
    }
}
