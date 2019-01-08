using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sonos.Integration.Models.SessionRequest
{
    [DataContract]
    public class CreateJoinSessionRequest
    {
        [DataMember (Name = "accountId")] public string AccountId { get; set; }
        [DataMember (Name = "appContext")] public string AppContext { get; set; }
        [DataMember (Name = "appId")] public string AppId { get; set; }
        [DataMember (Name = "customData")] public string CustomData { get; set; }
    }
}
