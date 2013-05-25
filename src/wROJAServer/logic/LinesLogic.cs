using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;

namespace wROJAServer.logic
{
    public class LinesLogic : AbstractLogic
    {
        private static string GetAllLinesString = "SELECT lines.id AS lineId, lines.number AS lineNumber, routes.id AS routeID, stops.name AS stopName" +
                " FROM (lines LEFT JOIN routes ON lines.id = routes.lineID)" +
                " LEFT JOIN stops ON routes.stopID = stops.id ORDER BY lines.number ASC";

        private static string GetStopsForLineString = @"SELECT stops.id AS stopID, stops.name AS stopName, stops.communeID AS stopCommune,"
                        + " routesdetails.onDemand AS stopOnDemand, routesdetails.obligatory AS stopObligatory, routesdetails.id AS routeDetailsID "
                        + " FROM routesdetails LEFT JOIN stops ON routesdetails.stopID = stops.id WHERE routesdetails.lineID = @LineID" 
                        + " AND routesdetails.routeID = @RouteID AND routesdetails.stopID != -1 ORDER BY routeDetailsID";

        public LinesLogic() {}

        public List<Line> GetAllLines()
        {
            using (SQLiteTransaction transaction = databaseConnection.BeginTransaction())
            {
                SQLiteCommand query = new SQLiteCommand(GetAllLinesString, databaseConnection);
                SQLiteDataReader reader = query.ExecuteReader();

                List<Line> result = new List<Line>();

                while (reader.Read())
                {
                    result.Add(new Line(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                }

                reader.Dispose();
                transaction.Commit();

                return result;
            }
        }

        public List<Stop> GetStopsForLine(int lineID, int routeID)
        {
            using (SQLiteTransaction transaction = databaseConnection.BeginTransaction())
            {
                SQLiteCommand query = new SQLiteCommand(GetStopsForLineString, databaseConnection);
                query.Parameters.Add(new SQLiteParameter("@LineID", lineID));
                query.Parameters.Add(new SQLiteParameter("@RouteID", routeID));
                SQLiteDataReader reader = query.ExecuteReader();

                List<Stop> result = new List<Stop>();

                while (reader.Read())
                {
                    result.Add(new Stop(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(5)));
                }

                reader.Dispose();
                transaction.Commit();

                return result;
            }
        }       
    }
}
