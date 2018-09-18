using System.Runtime.Serialization;

namespace Sonos.Integration.Models.SonosStatus
{
    [DataContract (Namespace = "")]
    public class PlayMode
    {
        [DataMember (Name = "repeat")] public bool Repeat { get; set; }
        [DataMember (Name = "repeatOne")] public bool RepeatOne { get; set; }
        [DataMember (Name = "crossfade")] public bool CrossFade { get; set; }
        [DataMember (Name = "shuffle")] public bool Shuffle { get; set; }
    }
}