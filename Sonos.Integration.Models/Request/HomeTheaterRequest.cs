using System.Runtime.Serialization;

namespace Sonos.Integration.Models.Request
{
    [DataContract (Namespace = "")]
    public class HomeTheaterRequest
    {
        [DataMember (Name = "playerId")] public string PlayerId { get; set; }
    }
}