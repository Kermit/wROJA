using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;
using wROJAServer.logic;

namespace wROJAServer.services
{
    public class StopsService : IStopsService
    {
        private StopsLogic logic = new StopsLogic();

        public List<Stop> GetAllStops()
        {
            return logic.GetAllStops();
        }
    }
}
