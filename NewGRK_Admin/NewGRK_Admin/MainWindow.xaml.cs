using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace NewGRK_Admin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserInfo UserInfo { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            if (File.Exists("GRK_UserInfo.xml"))
            {
                using (FileStream fs = new FileStream("GRK_UserInfo.xml", FileMode.OpenOrCreate))
                {
                    UserInfo = (UserInfo)serializer.Deserialize(fs);
                }
            }
            else
            {
                UserSettings userSettings = new UserSettings();
                userSettings.ShowDialog();
                using (FileStream fs = new FileStream("GRK_UserInfo.xml", FileMode.OpenOrCreate))
                {
                    UserInfo = (UserInfo)serializer.Deserialize(fs);
                }
            }

        }

        private void BtnCreateObject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MiSettings_Click(object sender, RoutedEventArgs e)
        {
            UserSettings userSettings = new UserSettings();
            userSettings.ShowDialog();
        }
    }
}
