using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;
using wROJAServer.logic;

namespace wROJAServer.services
{
    public class SearchService : ISearchService
    {
        private SearchLogic logic = new SearchLogic();
        private StopsLogic stopsLogic = new StopsLogic();

        public List<RouteOptions> GetStraightRoutes(int startStopID, int endStopID)
        {
            return logic.GetStraightRoutes(startStopID, endStopID);
        }

        public List<Timetable> GetTimetable(int routeDetailsID)
        {
            return logic.GetTimetable(routeDetailsID);
        }
    }
}
