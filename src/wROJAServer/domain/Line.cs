using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.domain
{
    [DataContract]
    public class Line
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public string WayName { get; set; }

        public Line() { }

        public Line(int id, string number, int routeID, string wayName)
        {
            ID = id;
            Number = number;
            RouteID = routeID;
            WayName = wayName;
        }
    }
}
