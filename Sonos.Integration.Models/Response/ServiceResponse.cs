using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sonos.Integration.Models.Response
{
    [DataContract(Namespace = "")]
    public class ServiceResponse
    {
        [DataMember(Name = "userIdHashCode")] public string UserIdHashCode { get; set; }
        [DataMember(Name = "nickname")] public string Nickname { get; set; }
        [DataMember(Name = "id")] public string Id { get; set; }
        [DataMember(Name = "isGuest")] public bool IsGuest { get; set; }
        [DataMember(Name = "service")] public object Service { get; set; }
    }
}
