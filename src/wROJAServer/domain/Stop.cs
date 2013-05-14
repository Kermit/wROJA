using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.domain
{
    [DataContract]
    public class Stop
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int CommuneID { get; set; }
        [DataMember]
        public string CommuneName { get; set; }
        [DataMember]
        public int RouteDetailsID { get; set; }

        public Stop() { }

        public Stop(int id, string name, int communeID, int routeDetailsID)
        {
            ID = id;
            Name = name;
            CommuneID = communeID;
            RouteDetailsID = routeDetailsID;
        }

        public Stop(int id, string name, string communeName)
        {
            ID = id;
            Name = name;
            CommuneName = communeName;
        }
    }
}
