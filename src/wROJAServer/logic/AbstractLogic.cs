using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.domain;

namespace wROJAServer.logic
{
    public abstract class AbstractLogic
    {
        private static string GetTimetableForStopString = "SELECT days.name AS dayName, times.time AS timeTable, times.legend AS timetableLegend"
                        + " FROM times LEFT JOIN days ON times.dayID = days.id WHERE times.routeDetailsID = {0}";

        public SQLiteConnection databaseConnection
        {
            get
            {
                return Server.getInstance().databaseConnection;
            }
        }

        public List<Timetable> GetTimetable(int routeDetailsID)
        {
            using (SQLiteTransaction transaction = databaseConnection.BeginTransaction())
            {
                SQLiteCommand query = new SQLiteCommand(String.Format(GetTimetableForStopString, routeDetailsID), databaseConnection);
                SQLiteDataReader reader = query.ExecuteReader();

                List<Timetable> result = new List<Timetable>();

                while (reader.Read())
                {
                    object lastField = reader.GetValue(2);
                    result.Add(new Timetable(reader.GetString(0), reader.GetString(1), reader.GetValue(2).GetType() == typeof(System.DBNull) ? "" : reader.GetString(2)));
                }

                reader.Dispose();
                transaction.Commit();

                return result;
            }
        }
    }
}
