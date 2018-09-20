using System.Runtime.Serialization;

namespace Sonos.Integration.Models.Response
{
    [DataContract (Namespace = "")]
    public class GroupResponse
    {
        [DataMember (Name = "group")] public Group Group { get; set; }
        
    }
}