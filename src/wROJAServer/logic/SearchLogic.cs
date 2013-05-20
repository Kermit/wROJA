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
        private static string LinesQueryString = @"SELECT id, lineID, routeID FROM routesdetails WHERE stopID = @StopID";
        private static string GetRouteDetailsIDQueryString = @"SELECT id FROM routesdetails WHERE lineID = @LineID AND routeID = @RouteID AND stopID = @StopID";
        private static string GetLineAndStopNamesQueryString = @"SELECT lines.number AS lineNumber, stops.name AS stopName"
                           + " FROM (routes INNER JOIN stops ON routes.stopID = stops.id) INNER JOIN"
                           + " lines ON routes.lineID = lines.id WHERE routes.id = @ID AND routes.lineID = @LineID";
        private static string CRSCheckRoute = @"SELECT routesdetails.id AS routedetailID,"
                   + " stops.name AS stopName"
                   + " FROM ((routesdetails INNER JOIN lines ON routesdetails.lineID = lines.id)"
                   + " INNER JOIN routes ON routesdetails.routeID = routes.id) INNER JOIN stops ON"
                   + " routes.stopID = stops.id WHERE routesdetails.stopID = @StopID AND routesdetails.lineID = @LineID AND"
                   + " routesdetails.routeID = @RouteID";

        public SearchLogic() { }

        public List<RouteOptions> GetStraightRoutes(int startStopID, int endStopID)
        {            
            using (SQLiteTransaction transaction = databaseConnection.BeginTransaction())
            {
                List<RouteOptions> result = new List<RouteOptions>();

                SQLiteCommand query = new SQLiteCommand(LinesQueryString, databaseConnection);
                query.Parameters.Add(new SQLiteParameter("@StopID", startStopID));
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
                    query.Parameters.Add(new SQLiteParameter("@StopID", endStopID));
                    query.Parameters.Add(new SQLiteParameter("@LineID", lineID));
                    query.Parameters.Add(new SQLiteParameter("@RouteID", routeID));
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
            SQLiteCommand query = new SQLiteCommand(GetLineAndStopNamesQueryString, databaseConnection);
            query.Parameters.Add(new SQLiteParameter("@ID", routeID));
            query.Parameters.Add(new SQLiteParameter("@LineID", lineID));
            SQLiteDataReader reader = query.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetString(0) + " -> " + reader.GetString(1);
            }

            return null;
        }

        private int GetRouteDetailsID(int lineID, int routeID, int startStopID)
        {
            SQLiteCommand query = new SQLiteCommand(GetRouteDetailsIDQueryString, databaseConnection);
            query.Parameters.Add(new SQLiteParameter("@LineID", lineID));
            query.Parameters.Add(new SQLiteParameter("@RouteID", routeID));
            query.Parameters.Add(new SQLiteParameter("@StopID", startStopID));
            return Convert.ToInt32((Int64)query.ExecuteScalar());
        }
    }
}
