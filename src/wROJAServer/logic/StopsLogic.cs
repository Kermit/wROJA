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
    }
}
