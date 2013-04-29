using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.services
{
    public class LinesService : ILinesService
    {
        public List<string> getAllLines()
        {
            // Mockowane dane.
            List<string> result = new List<string>();
            result.Add("22");
            result.Add("222");

            return result;
        }
    }
}
