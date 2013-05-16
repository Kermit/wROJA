using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.services
{
    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        List<wROJAServer.domain.RouteOptions> GetStraightRoutes(int startStopID, int endStopID);
    }
}
