﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TideTableWCF.Request;
using TideTableWCF.Response;

namespace TideTableWCF
{
    // using a ServiceContract to specify the operations that are available for the service client to consume. 
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, UriTemplate = "/GetTideData")]
        List<TideTableResponse> GetTideData(TideTableRequest tideValues);

        // TODO: Add your service operations here
    }

}
