using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public enum GRK_DBType { MSSQL = 0, Postgres = 1, Oracle = 2 }
    public interface IGRK_DB
    {
        string ConnectionString { get; set; }
        string ServerName { get; set; }
        string DataBaseName { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        GRK_DBType GRK_DBType { get; }

        bool TestConnection();
        bool TestConnection(string conString);
        bool TestConnection(string serverName, string dbName, string login, string password);

        int GetLastID();
        List<ObjectType> GetObjectTypes();
        List<ObjectType> GetGRKObjects();
    }
}
