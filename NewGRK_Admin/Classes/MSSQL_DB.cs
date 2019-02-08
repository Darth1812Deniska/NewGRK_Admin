using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    class MSSQL_DB : IGRK_DB
    {
        public string ConnectionString { get ; set ; }
        public string ServerName { get; set; }
        public string DataBaseName { get ; set ; }
        public string Login { get ; set ; }
        public string Password { get ; set ; }

        public MSSQL_DB (string serverName, string dbName, string login, string password)
        {
            ServerName = serverName;
            DataBaseName = dbName;
            Login = login;
            Password = password;

            ConnectionString = $"Data Source={ServerName};Initial Catalog={DataBaseName};User ID={Login};Password={Password}";
        }

        public bool TestConnection(string conString)
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
            return tryConnection(sqlConnection);
        }

        public bool TestConnection(string serverName, string dbName, string login, string password)
        {
            string conString = $"Data Source={serverName};Initial Catalog={dbName};User ID={login};Password={password}";
            SqlConnection sqlConnection = new SqlConnection (conString);
            return tryConnection(sqlConnection);
        }

        public bool TestConnection()
        {
            string conString = $"Data Source={ServerName};Initial Catalog={DataBaseName};User ID={Login};Password={Password}";
            SqlConnection sqlConnection = new SqlConnection(conString);
            return tryConnection(sqlConnection);
        }

        private bool tryConnection(SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
