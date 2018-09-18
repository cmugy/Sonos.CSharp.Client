using System.Runtime.Serialization;

namespace Sonos.Integration.Models.SonosStatus
{
    [DataContract (Namespace = "")]
    public class PlayBackOptions
    {
        [DataMember (Name = "canSkip")] public bool CanSkip { get; set; }
        [DataMember (Name = "canSkipBack")] public bool CanSkipBack { get; set; }
        [DataMember (Name = "canSeek")] public bool CanSeek { get; set; }
        [DataMember (Name = "canRepeat")] public bool CanRepeat { get; set; }
        [DataMember (Name = "canRepeatOne")] public bool CanRepeatOne { get; set; }
        [DataMember (Name = "canCrossfade")] public bool CanCrossfade { get; set; }
        [DataMember (Name = "canShuffle")] public bool CanShuffle { get; set; }
    }
}