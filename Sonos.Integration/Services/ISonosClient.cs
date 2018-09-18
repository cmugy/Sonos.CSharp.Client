using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sonos.Integration.Models;
using Sonos.Integration.Models.SonosStatus;

namespace Sonos.Integration.Services
{
    public interface ISonosClient
    {
        void ConnectToSonos();
        void ConnectWithCode();
        HouseHold GetSonosHouseHolds();
        string GetNewRefreshedToken(string refreshToken);
        InternalHouseHoldResponse GetSonosSetUp(string id);
        void PlayOnGroup(string groupId);
        int GetGroupVolume(string groupId);
        void SetGroupVolume(SetGroupVolume groupVolume);
        PlayBackStatusResponse GetPlaybackStatusResponse(string groupId);


    }
}
