using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    [Serializable]
    public class ServerInfo
    {
        public string ServerName { get; set; }
        public GRK_DBType GRK_DBType { get; set; }
        public string DBName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ServerInfo () { }

        public ServerInfo (string serverName, GRK_DBType grk_DBType, string dbName, string login, string password)
        {
            ServerName = serverName;
            GRK_DBType = grk_DBType;
            DBName = dbName;
            Login = login;
            Password = password;
        }

        public bool Equals(ServerInfo other)
        {
            if (other == null)
                return false;
            if (this.ServerName == other.ServerName)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            ServerInfo servInfoObj = obj as ServerInfo;
            if (servInfoObj == null)
                return false;
            else
                return Equals(servInfoObj);
        }

        public override int GetHashCode()
        {
            return this.ServerName.GetHashCode();
        }

        public override string ToString()
        {
            return this.ServerName;
        }
    }
}
