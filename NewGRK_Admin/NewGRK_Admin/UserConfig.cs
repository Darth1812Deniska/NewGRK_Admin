using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGRK_Admin
{
    class UserConfig
    {
        public string UserName { get; set; }
        public string DeveloperFolderPath { get; set; }

        public UserConfig (string _userName, string _developerFolderPath)
        {
            UserName = _userName;
            DeveloperFolderPath = _developerFolderPath;
        }
    }
}
