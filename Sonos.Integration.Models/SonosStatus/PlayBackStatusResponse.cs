using System.Runtime.Serialization;

namespace Sonos.Integration.Models.SonosStatus
{
    [DataContract(Namespace = "")]
    public class PlayBackStatusResponse
    {
        [DataMember(Name = "playbackState")] public string Status { get; set; }
        [DataMember(Name = "queueVersion")] public string QueueVersion { get; set; }
        [DataMember(Name = "itemId")] public string ItemId { get; set; }
        [DataMember(Name = "positionMillis")] public int PositionMillis { get; set; }
        [DataMember(Name = "playModes")] public PlayMode PlayMode { get; set; }
        [DataMember(Name = "availablePlaybackActions")]
        public PlayBackOptions PlayBackOptions { get; set; }

    }
}