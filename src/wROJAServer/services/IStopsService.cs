using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.services
{
    [ServiceContract]
    public interface IStopsService
    {
        [OperationContract]
        List<wROJAServer.domain.Stop> GetAllStops();
    }
}
