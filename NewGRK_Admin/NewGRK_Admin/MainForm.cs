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
using System.Xml.Serialization;

namespace NewGRK_Admin
{
    public partial class MainForm : Form
    {
        UserConfig config = new UserConfig();
        public MainForm()
        {
            InitializeComponent();
            
            if (!File.Exists("GA_UserConfig.xml"))
            {
                SettingsForm settings = new SettingsForm();
                settings.ShowDialog();
            }
            else
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load("GA_UserConfig.xml");
                using (FileStream fs = new FileStream("GA_UserConfig.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserConfig));
                    config = (UserConfig)serializer.Deserialize(fs);
                }
            }
        }

        private void btnCreateObject_Click(object sender, EventArgs e)
        {
            grkObjectForm objectForm = new grkObjectForm(config);
            objectForm.ShowDialog();
        }
    }
}
