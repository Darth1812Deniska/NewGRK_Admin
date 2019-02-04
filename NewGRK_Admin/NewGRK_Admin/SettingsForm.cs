using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace NewGRK_Admin
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSelDevDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult res = fileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                edtDevDirectory.Text = fileDialog.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserConfig config = new UserConfig(edtUserName.Text, edtDevDirectory.Text);
            XmlSerializer serializer = new XmlSerializer(config.GetType());
            using (FileStream fs = new FileStream("GA_UserConfig.xml", FileMode.Create))
            {
                serializer.Serialize(fs, config);
            }
            this.Close();
            this.Dispose();
        }
    }
}
