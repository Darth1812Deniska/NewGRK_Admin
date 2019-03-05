using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewGRK_Admin
{
    class PostgreSQL_DB : IGRK_DB
    {
        private readonly GRK_DBType _gRK_DBType;
        private readonly NpgsqlConnection _connection;

        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
        public string ServerName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private NpgsqlConnection Connection => _connection;
        public GRK_DBType GRK_DBType => _gRK_DBType;
        public PostgreSQL_DB(string serverName, string dbName, string login, string password)
        {
            ServerName = serverName;
            DataBaseName = dbName;
            Login = login;
            Password = password;
            ConnectionString = $"Server={ServerName};Port=5432;Database={DataBaseName};User Id={Login};Password = {Password};";

            _connection = new NpgsqlConnection(ConnectionString);
            _gRK_DBType = GRK_DBType.Postgres;
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

        public int GetLastID()
        {
            Connection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select ot.\"ID\" from dbo.ldobjecttype ot order by ot.\"ID\" desc limit 1;";
            int result = Convert.ToInt32(command.ExecuteScalar());
            Connection.Close();
            return result;
        }

        public List<ObjectType> GetObjectTypes()
        {
            List<ObjectType> result = new List<ObjectType>();
            Connection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT ot.\"ID\" , ot.\"Name\" , ot.\"DisplayLabel\" FROM dbo.LDOBJECTTYPE ot ORDER BY ot.\"ID\"; ";
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string displayLabel = reader.GetString(2);

                    ObjectType objectType = new ObjectType(id, name, displayLabel);
                    result.Add(objectType);
                }
            }
            Connection.Close();
            return result;
        }

        public List<ObjectType> GetGRKObjects()
        {
            List<ObjectType> result = new List<ObjectType>();
            Connection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = Connection;
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT ot.\"ID\" , ot.\"Name\" , ot.\"DisplayLabel\" FROM dbo.LDOBJECTTYPE ot WHERE ot.\"System\" = '-' ORDER BY ot.\"ID\";";
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string displayLabel = reader.GetString(2);

                    ObjectType objectType = new ObjectType(id, name, displayLabel);
                    result.Add(objectType);
                }
            }
            Connection.Close();
            return result;
        }
    }
}
