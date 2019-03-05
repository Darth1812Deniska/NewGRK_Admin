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
        private readonly GRK_DBType _gRK_DBType;
        private readonly SqlConnection _sqlConnection;

        public string ConnectionString { get; set; }
        public string ServerName { get; set; }
        public string DataBaseName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private SqlConnection SqlConnection => _sqlConnection;
        public GRK_DBType GRK_DBType => _gRK_DBType;
        public MSSQL_DB(string serverName, string dbName, string login, string password)
        {
            ServerName = serverName;
            DataBaseName = dbName;
            Login = login;
            Password = password;

            ConnectionString = $"Data Source={ServerName};Initial Catalog={DataBaseName};User ID={Login};Password={Password}";
            _sqlConnection = new SqlConnection(ConnectionString);
            _gRK_DBType = GRK_DBType.MSSQL;
        }

        public bool TestConnection(string conString)
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
            return tryConnection(sqlConnection);
        }

        public bool TestConnection(string serverName, string dbName, string login, string password)
        {
            string conString = $"Data Source={serverName};Initial Catalog={dbName};User ID={login};Password={password}";
            SqlConnection sqlConnection = new SqlConnection(conString);
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

        public int GetLastID()
        {
            SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = SqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT TOP 1 ot.ID FROM dbo.LDOBJECTTYPE ot ORDER BY ot.ID DESC";
            var result = Convert.ToInt32(sqlCommand.ExecuteScalar());
            SqlConnection.Close();
            return result;
        }

        public List<ObjectType> GetObjectTypes()
        {
            List<ObjectType> result = new List<ObjectType>();
            SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = SqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT ot.ID , ot.Name , ot.DisplayLabel FROM dbo.LDOBJECTTYPE ot ORDER BY ot.ID; ";
            SqlDataReader reader = sqlCommand.ExecuteReader();
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
            SqlConnection.Close();
            return result;
        }

        public List<ObjectType> GetGRKObjects()
        {
            List<ObjectType> result = new List<ObjectType>();
            SqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = SqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            string sqlText = $"SELECT  ot.ID , ot.Name , ot.DisplayLabelFROM dbo.LDOBJECTTYPE ot WHERE ot.System = '-' ORDER BY ot.ID";
            sqlCommand.CommandText = sqlText;
            SqlDataReader reader = sqlCommand.ExecuteReader();
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
            SqlConnection.Close();
            return result;
        }
    }
}
