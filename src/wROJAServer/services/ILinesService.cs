using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.services
{
    [ServiceContract]
    public interface ILinesService
    {
        // TODO chwilowo zwracam string
        [OperationContract]
        List<string> getAllLines();        
    }
}
