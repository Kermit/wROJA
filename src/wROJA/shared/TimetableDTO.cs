using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wROJA.shared
{
    public class TimetableDTO
    {
        public string DayName { get; set; }
        public string Table { get; set; }
        public string Legend { get; set; }

        public TimetableDTO() { }

        public TimetableDTO(string dayName, string table, string legend)
        {
            DayName = dayName;
            Table = table;
            Legend = legend;
        }
    }    
}
