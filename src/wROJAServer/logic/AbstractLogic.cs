using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wROJAServer.logic
{
    public abstract class AbstractLogic
    {
        public SQLiteConnection databaseConnection
        {
            get
            {
                return Server.getInstance().databaseConnection;
            }
        }
    }
}
