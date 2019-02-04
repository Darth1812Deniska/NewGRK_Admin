using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGRK_Admin
{
    public partial class grkObjectForm : Form
    {
        UserConfig userConfig;
        public grkObjectForm()
        {
            InitializeComponent();
        }

        public grkObjectForm (UserConfig _userConfig)
        {
            InitializeComponent();
            userConfig = _userConfig;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(userConfig.UserName);
            MessageBox.Show(userConfig.DeveloperFolderPath);
        }
    }
}
