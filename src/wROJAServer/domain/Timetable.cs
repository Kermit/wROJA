using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.domain
{
    [DataContract]
    public class Timetable
    {
        [DataMember]
        public string DayName { get; set; }
        [DataMember]
        public string Table { get; set; }
        [DataMember]
        public string Legend { get; set; }

        public Timetable() { }

        public Timetable(string dayName, string table, string legend)
        {
            DayName = dayName;
            Table = table;
            Legend = legend;
        }
    }
}
