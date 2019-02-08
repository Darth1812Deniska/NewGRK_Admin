using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    class IGRK_DB
    {
        string ConnectionString { get; set; }
        string ServerName { get; set; }
        string DataBaseName { get; set; }
        string Login { get; set; }
        string Password { get; set; }

        bool TestConnection();
        bool TestConnection(string conString);
        bool TestConnection(string serverName, string dbName, string login, string password);
    }
}
