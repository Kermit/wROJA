using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using wROJA.shared;

namespace wROJA.logic
{    
    public class LinesLogic : AbtractLogic
    {
        private LinesService.ILinesService linesService = new LinesService.LinesServiceClient();

        public LinesService.Line[] GetAllLines()
        {
            return linesService.GetAllLines();
        }

        public LinesService.Stop[] GetStopsForLine(LinesService.Line line)
        {
            return linesService.GetStopsForLine(line.ID, line.RouteID);
        }

        public List<Paragraph> GetTimetable(LinesService.Stop stop)
        {
            List<TimetableDTO> timetable = new List<TimetableDTO>();
            foreach (LinesService.Timetable obj in linesService.GetTimetable(stop.RouteDetailsID))
            {
                timetable.Add(new TimetableDTO(obj.DayName, obj.Table, obj.Legend));
            }

            return PrepareTimetable(timetable);
        }
    }
}
