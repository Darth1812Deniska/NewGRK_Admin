using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace NewGRK_Admin
{
    /// <summary>
    /// Логика взаимодействия для UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Window
    {
        
        public UserSettings()
        {
            InitializeComponent();
            UserInfo userInfo = new UserInfo();
            XmlSerializer serializer = new XmlSerializer(userInfo.GetType());

            try
            {
                using (FileStream fs = new FileStream("GRK_UserInfo.xml", FileMode.OpenOrCreate))
                {
                    userInfo = (UserInfo)serializer.Deserialize(fs);
                }
                txtUserName.Text = userInfo.UserName;
                txtDirectory.Text = userInfo.DeveloperFolderPath;
            }
            catch
            {

            }
        }

        private void BtnSetDirectory_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtDirectory.Text = folder.SelectedPath;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            wndUserSettings.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            UserInfo userInfo = new UserInfo(txtUserName.Text, txtDirectory.Text);
            XmlSerializer serializer = new XmlSerializer(userInfo.GetType());

            using (FileStream fs = new FileStream("GRK_UserInfo.xml", FileMode.Create))
            {
                serializer.Serialize(fs, userInfo);
            }
            wndUserSettings.Close();
        }
    }
}
