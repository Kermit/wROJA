using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using wROJA.shared;

namespace wROJA.logic
{
    public class StopsLogic : AbtractLogic
    {
        private StopsService.IStopsService stopsService = new StopsService.StopsServiceClient();

        public StopsService.Stop[] GetAllStops()
        {            
            return stopsService.GetAllStops();
        }

        public StopsService.Line[] GetLinesForStop(StopsService.Stop stop)
        {
            return stopsService.GetLinesForStop(stop.ID);
        }

        public List<Paragraph> GetTimetable(StopsService.Line line)
        {
            List<TimetableDTO> timetable = new List<TimetableDTO>();
            foreach (StopsService.Timetable obj in stopsService.GetTimetable(line.RouteID))
            {
                timetable.Add(new TimetableDTO(obj.DayName, obj.Table, obj.Legend));
            }

            return PrepareTimetable(timetable);
        }
    }
}
