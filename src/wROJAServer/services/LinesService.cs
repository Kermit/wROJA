using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;
using wROJAServer.logic;

namespace wROJAServer.services
{
    public class LinesService : ILinesService
    {
        private LinesLogic logic = new LinesLogic();

        public List<Line> GetAllLines()
        {
            return logic.GetAllLines();
        }

        public List<Stop> GetStopsForLine(int lineID, int routeID)
        {
            return logic.GetStopsForLine(lineID, routeID);
        }

        public List<Timetable> GetTimetableForStop(int routeDetailsID)
        {
            return logic.GetTimetableForStop(routeDetailsID);
        }
    }
}
