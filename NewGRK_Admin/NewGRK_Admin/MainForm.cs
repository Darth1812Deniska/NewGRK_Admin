using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace NewGRK_Admin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (!File.Exists("NewGrkAdminUserConf.xml"))
            {
                MessageBox.Show("");
            }
            else
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load("NewGrkAdminUserConf.xml");
            }
            
            
        }

    }
}
