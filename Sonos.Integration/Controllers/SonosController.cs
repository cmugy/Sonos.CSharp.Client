using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sonos.Integration.Models;
using Sonos.Integration.Models.Request;
using Sonos.Integration.Models.Response;
using Sonos.Integration.Models.SonosStatus;
using Sonos.Integration.ParameterValidation;
using Sonos.Integration.Services;

namespace Sonos.Integration.Controllers
{
    public class SonosController : Controller
    {
        private readonly ISonosClient _client;
        private readonly IParameterValidator _parameterValidator;

        public SonosController(ISonosClient client, IParameterValidator parameterValidator)
        {
            _client = client;
            _parameterValidator = parameterValidator;
        }

        /// <summary>
        /// Gets sonos authorization
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/sonos")]
        public object GetSonosAuthorization()
        {
            //_client.ConnectToSonos();
            //_client.ConnectWithCode();

            var tok = _client.GetNewRefreshedToken("09efe8c1-d142-42fd-9248-5f966a6c31d8");

            return tok;
        }

        /// <summary>
        /// Gets household object from Sonos API
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/sonos/household")]
        public HouseHold GetSonosHouseHolds()
        {
            return _client.GetSonosHouseHolds();
        }

        /// <summary>
        /// Gets all the sonos metadata in a given household
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("api/sonos/household/{id}")]
        public InternalHouseHoldResponse GetSonosSetUp(string id)
        {
            return _client.GetSonosSetUp(id);
        }

        /// <summary>
        /// Starts playback on a given group
        /// </summary>
        /// <param name="groupId"></param>
        [HttpPost, Route("api/sonos/group/{groupId}")]
        public void PlayOnSonosGroup(string groupId)
        {
            _client.PlayOnGroup(groupId);
        }


        /// <summary>
        /// Gets volme for a given group in range 0-100
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet, Route("api/sonos/group/volume/{groupId}")]
        public int GetGroupVolume(string groupId)
        {
            return _client.GetGroupVolume(groupId);
        }

        /// <summary>
        /// Sets the group volume
        /// </summary>
        /// <param name="setGroupVolume"></param>
        [HttpPost, Route("api/sonos/setVolume")]
        public void SetGroupVolume([FromBody] SetGroupVolume setGroupVolume)
        {
            _parameterValidator.VolumeLevelCheck(setGroupVolume.Volume);
            _client.SetGroupVolume(setGroupVolume);
        }

        /// <summary>
        /// Returns the current response of the group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet, Route("api/sonos/status/{groupId}")]
        public PlayBackStatusResponse GetGroupStatus(string groupId)
        {
            return _client.GetPlaybackStatusResponse(groupId);
        }

        /// <summary>
        /// Groups players based on their playerIds
        /// </summary>
        [HttpPost, Route("api/sonos/groupPlayers")]
        public GroupResponse GroupPlayers([FromBody] PlayerRequest request)
        {
            return _client.CreateGroup(request);
        }

        /// <summary>
        /// Switch input to TV for compatible players
        /// </summary>
        /// <param name="playerId"></param>
        [HttpPost, Route("api/sonos/homeTheatre")]
        public void SwitchPlayerInputToTv(string playerId)
        {
            _client.SwitchPlayerToTv(playerId);
        }

        /// <summary>
        /// Create or joins an existing session
        /// </summary>
        /// <param name="groupId"></param>
        [HttpPost, Route("api/sonos/joinOrCreate/{groupId}")]
        public void JoinOrCreateSonosSession(string groupId)
        {
            _client.JoinOrCreateSession(groupId);
        }



    }
}