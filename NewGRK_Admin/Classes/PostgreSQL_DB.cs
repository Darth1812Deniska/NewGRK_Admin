using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewGRK_Admin
{
    class PostgreSQL_DB : IGRK_DB
    {
        public string ConnectionString { get ; set ; }
        public string DataBaseName { get ; set ; }
        public string ServerName { get ; set ; }
        public string Login { get ; set ; }
        public string Password { get ; set ; }

        public PostgreSQL_DB (string serverName, string dbName, string login, string password)
        {
            ServerName = serverName;
            DataBaseName = dbName;
            Login = login;
            Password = password;
            ConnectionString = $"Server={ServerName};Port=5432;Database={DataBaseName};User Id={Login};Password = {Password};";
        }

        public bool TestConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
            return tryConnection(connection);
        }

        public bool TestConnection(string conString)
        {
            NpgsqlConnection connection = new NpgsqlConnection(conString);
            return tryConnection(connection);
        }

        public bool TestConnection(string serverName, string dbName, string login, string password)
        {
            string conString = $"Server={serverName};Port=5432;Database={dbName};User Id={login};Password = {password};";
            NpgsqlConnection connection = new NpgsqlConnection(conString);
            return tryConnection(connection);
        }

        private bool tryConnection(NpgsqlConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
