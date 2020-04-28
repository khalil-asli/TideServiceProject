using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TideTableWCF.Request
{
//Using a data contract with dataMember that user need to give so he can make a request
    [DataContract]
    public class TideTableRequest
    {
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public List<string> timeOfTide { get; set; }
        [DataMember]
        public List<TideTableModel> TideTableData { get; set; }
    }

    [DataContract]
    public class TideTableModel
    {
        [DataMember]
        public string coefficient { get; set; }
        [DataMember]
        public string time { get; set; }
        [DataMember]
        public string tideHeight { get; set; }
    }
}
