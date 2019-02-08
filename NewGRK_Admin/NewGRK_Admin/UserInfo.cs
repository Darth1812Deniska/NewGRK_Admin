using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string DeveloperFolderPath { get; set; }

        public UserInfo()
        {
            UserName = String.Empty;
            DeveloperFolderPath = String.Empty;
        }

        public UserInfo (string userName, string developerFolderPath)
        {
            UserName = userName;
            DeveloperFolderPath = developerFolderPath;
        }
    }
}
