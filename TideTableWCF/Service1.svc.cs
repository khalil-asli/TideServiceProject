using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using TideTableWCF.Request;
using TideTableWCF.Response;
using TideTableWCF.TideHelper;

namespace TideTableWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public List<TideTableResponse> GetTideData(TideTableRequest tideValues)
        {
            TideHelper.TideHelper tideHelper = new TideHelper.TideHelper();
            List<TideTableResponse> tideTableResponses = new List<TideTableResponse>();
            foreach (string tideTime in tideValues.timeOfTide)
            {
                TideTableResponse tideTableResponse = new TideTableResponse();
                bool isTimeExists = tideHelper.GetTimeExists(tideValues.TideTableData.ToArray()[0].time, tideValues.TideTableData.ToArray()[1].time, tideTime);
                double tideHeight;
                if (isTimeExists)
                {
                    tideHeight = tideHelper.RuleOfTwelfh(tideValues.TideTableData.ToArray()[0].time, tideValues.TideTableData.ToArray()[1].time, tideValues.TideTableData.ToArray()[0].tideHeight, tideValues.TideTableData.ToArray()[1].tideHeight, tideTime);
                    tideTableResponse.CoEfficient = tideValues.TideTableData.ToArray()[0].coefficient;
                    tideTableResponse.Location = tideValues.location;
                    tideTableResponse.TideHeight = tideHeight + " Meter";
                    tideTableResponse.TideTime = tideTime;
                }
                else
                {
                    tideHeight = tideHelper.RuleOfTwelfh(tideValues.TideTableData.ToArray()[2].time, tideValues.TideTableData.ToArray()[3].time, tideValues.TideTableData.ToArray()[2].tideHeight, tideValues.TideTableData.ToArray()[3].tideHeight, tideTime);
                    tideTableResponse.CoEfficient = tideValues.TideTableData.ToArray()[0].coefficient;
                    tideTableResponse.Location = tideValues.location;
                    tideTableResponse.TideHeight = tideHeight + " Meter";
                    tideTableResponse.TideTime = tideTime;
                }
                tideTableResponses.Add(tideTableResponse);
            }
            return tideTableResponses;
        }

    }
}
