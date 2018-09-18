using System.Runtime.Serialization;

namespace Sonos.Integration.Models
{
    [DataContract (Namespace = "")]
    public class SonosAuth
    {
        [DataMember (Name = "grant_type")]
        public string GrantType { get; set; }
        
        [DataMember (Name = "redirect_url")]
        public string RedirectUrl { get; set; }
        
        [DataMember (Name = "code")]
        public string Code { get; set; }
        
    }
}