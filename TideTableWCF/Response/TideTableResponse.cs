using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TideTableWCF.Response
{
//Gestion des dataMember que l'utilisateur aura comme réponse après avoir faire une requête
    [DataContract]
    public class TideTableResponse
    {
        [DataMember]
        public string TideTime { get; set; }
        [DataMember]
        public string TideHeight { get; set; }
        [DataMember]
        public string CoEfficient { get; set; }
        [DataMember]
        public string Location { get; set; }
    }
}
