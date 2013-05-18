using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;

namespace wROJAServer.logic
{
    public class SearchLogic : AbstractLogic
    {
        private static string LinesQueryString = "SELECT id, lineID, routeID FROM routesdetails WHERE stopID = {0}";
        private static string CRSCheckRoute = "SELECT routesdetails.id AS routedetailID,"
                           + " stops.name AS stopName"
                           + " FROM ((routesdetails INNER JOIN lines ON routesdetails.lineID = lines.id)"
                           + " INNER JOIN routes ON routesdetails.routeID = routes.id) INNER JOIN stops ON"
                           + " routes.stopID = stops.id WHERE routesdetails.stopID = {0} AND routesdetails.lineID = {1} AND"
                           + " routesdetails.routeID = {2}";
        private static string GetRouteDetailsIDQueryString = "SELECT id FROM routesdetails WHERE lineID = {0} AND routeID = {1} AND stopID = {2}";
        private static string GetLineAndStopNamesQueryString = "SELECT lines.number AS lineNumber, stops.name AS stopName"
                           + " FROM (routes INNER JOIN stops ON routes.stopID = stops.id) INNER JOIN"
                           + " lines ON routes.lineID = lines.id WHERE routes.id = {0} AND routes.lineID = {1}";

        public SearchLogic() { }

        public List<RouteOptions> GetStraightRoutes(int startStopID, int endStopID)
        {            
            using (SQLiteTransaction transaction = databaseConnection.BeginTransaction())
            {
                List<RouteOptions> result = new List<RouteOptions>();

                SQLiteCommand query = new SQLiteCommand(String.Format(LinesQueryString, startStopID), databaseConnection);
                SQLiteDataReader linesReader = query.ExecuteReader();

                int ID;
                int lineID;
                int routeID;
                int secondID;

                while (linesReader.Read())
                {
                    ID = linesReader.GetInt32(0);
                    lineID = linesReader.GetInt32(1);
                    routeID = linesReader.GetInt32(2);

                    SQLiteCommand crsQuery = new SQLiteCommand(String.Format(CRSCheckRoute, endStopID, lineID, routeID), databaseConnection);
                    SQLiteDataReader CRSReader = crsQuery.ExecuteReader();

                    if (CRSReader.Read())
                    {
                        secondID = CRSReader.GetInt32(0);
                        if (secondID < ID)
                            continue;

                        string routeTitle = GetLineAndStopNames(routeID, lineID);

                        if (!String.IsNullOrEmpty(routeTitle))
                        {
                            result.Add(new RouteOptions(routeTitle, GetRouteDetailsID(lineID, routeID, startStopID)));
                        }
                    }

                    CRSReader.Dispose();
                }

                linesReader.Dispose();
                transaction.Commit();

                return result;
            }
        }

        private string GetLineAndStopNames(int routeID, int lineID)
        {
            SQLiteCommand query = new SQLiteCommand(String.Format(GetLineAndStopNamesQueryString, routeID, lineID), databaseConnection);
            SQLiteDataReader reader = query.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetString(0) + " -> " + reader.GetString(1);
            }

            return null;
        }

        private int GetRouteDetailsID(int lineID, int routeID, int startStopID)
        {
            SQLiteCommand query = new SQLiteCommand(String.Format(GetRouteDetailsIDQueryString, lineID, routeID, startStopID), databaseConnection);
            return Convert.ToInt32((Int64)query.ExecuteScalar());
        }
    }
}
