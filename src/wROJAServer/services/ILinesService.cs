using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;

namespace wROJAServer.services
{
    [ServiceContract]
    public interface ILinesService
    {        
        [OperationContract]
        List<wROJAServer.domain.Line> GetAllLines();

        [OperationContract]
        List<wROJAServer.domain.Stop> GetStopsForLine(int lineID, int routeID);

        [OperationContract]
        List<wROJAServer.domain.Timetable> GetTimetable(int routeDetailsID);
    }
}
