using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;

namespace wROJAServer.logic
{
    public class StopsLogic : AbstractLogic
    {
        private static string GetAllStopsString = "SELECT stops.id AS stopID, stops.name AS stopName, communes.name AS communeName FROM"
                + " stops LEFT JOIN communes ON stops.communeID = communes.id ORDER BY stops.name";

        private static string GetLinesForStopString = "SELECT lines.number AS lineNumber, routesdetails.id AS routedetailID,"
                        + " stops.name AS stopName FROM ((routesdetails INNER JOIN lines ON routesdetails.lineID = lines.id)"
                        + " INNER JOIN routes ON routesdetails.routeID = routes.id) INNER JOIN stops ON"
                        + " routes.stopID = stops.id WHERE routesdetails.stopID = {0}";

        public StopsLogic() { }

        public List<Stop> GetAllStops()
        {
            using (SQLiteTransaction transaction = databaseConnection.BeginTransaction())
            {
                SQLiteCommand query = new SQLiteCommand(GetAllStopsString, databaseConnection);
                SQLiteDataReader reader = query.ExecuteReader();

                List<Stop> result = new List<Stop>();

                while (reader.Read())
                {
                    result.Add(new Stop(reader.GetInt32(0), reader.GetString(1), reader.GetValue(2).GetType() == typeof(System.DBNull) ? "" : reader.GetString(2)));
                }

                reader.Dispose();
                transaction.Commit();

                return result;
            }
        }

        public List<Line> GetLinesForStop(int stopID)
        {
            using (SQLiteTransaction transaction = databaseConnection.BeginTransaction())
            {
                SQLiteCommand query = new SQLiteCommand(String.Format(GetLinesForStopString, stopID), databaseConnection);
                SQLiteDataReader reader = query.ExecuteReader();

                List<Line> result = new List<Line>();

                while (reader.Read())
                {
                    result.Add(new Line(0, reader.GetString(0), reader.GetInt32(1), reader.GetString(2)));
                }

                reader.Dispose();
                transaction.Commit();

                return result;
            }
        }        
    }
}
