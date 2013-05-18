using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using wROJA.shared;

namespace wROJA.logic
{
    public class SearchLogic : AbtractLogic
    {
        private SearchService.ISearchService service = new SearchService.SearchServiceClient();

        public SearchService.RouteOptions[] GetRoutes(int startStopID, int endStopID)
        {
            return service.GetStraightRoutes(startStopID, endStopID);
        }

        public List<Paragraph> GetTimetable(SearchService.RouteOptions routeOption)
        {
            List<TimetableDTO> timetable = new List<TimetableDTO>();
            foreach (SearchService.Timetable obj in service.GetTimetable(routeOption.RouteDetailsID))
            {
                timetable.Add(new TimetableDTO(obj.DayName, obj.Table, obj.Legend));
            }

            return PrepareTimetable(timetable);
        }
    }
}
