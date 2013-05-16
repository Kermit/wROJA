using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.domain
{
    [DataContract]
    public class RouteOptions
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public int RouteDetailsID { get; set; }

        public RouteOptions() { }

        public RouteOptions(string text, int routeDetailsID)
        {
            this.Text = text;
            this.RouteDetailsID = routeDetailsID;
        }
    }
}
