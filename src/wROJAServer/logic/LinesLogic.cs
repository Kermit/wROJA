﻿using System;
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

        private static string GetStopsForLineString = "SELECT stops.id AS stopID, stops.name AS stopName, stops.communeID AS stopCommune,"
                        + " routesdetails.onDemand AS stopOnDemand, routesdetails.obligatory AS stopObligatory, routesdetails.id AS routeDetailsID "
                        + " FROM routesdetails LEFT JOIN stops ON routesdetails.stopID = stops.id WHERE routesdetails.lineID = {0}" 
                        + " AND routesdetails.routeID = {1} AND routesdetails.stopID != -1 ORDER BY routeDetailsID";

        private static string GetTimetableForStopString = "SELECT days.name AS dayName, times.time AS timeTable, times.legend AS timetableLegend"
                        + " FROM times LEFT JOIN days ON times.dayID = days.id WHERE times.routeDetailsID = {0}";

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
                SQLiteCommand query = new SQLiteCommand(String.Format(GetStopsForLineString, lineID, routeID), databaseConnection);
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

        public List<Timetable> GetTimetableForStop(int routeDetailsID)
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