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

        private const string OrderInfosFileName = "GRK_OrderInfos.xml";
        private const string UserInfoFileName = "GRK_UserInfo.xml";
        
        private UserInfo _userInfo;

        private List<OrderInfo> OrderInfos => GetOrderInfos();
        private UserInfo UserInfo => _userInfo;
        public MainWindow()
        {
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
            if (File.Exists(UserInfoFileName))
            {
                using (FileStream fs = new FileStream(UserInfoFileName, FileMode.OpenOrCreate))
                {
                    _userInfo = (UserInfo)serializer.Deserialize(fs);
                }
            }
            else
            {
                UserSettings userSettings = new UserSettings();
                userSettings.ShowDialog();
                using (FileStream fs = new FileStream(UserInfoFileName, FileMode.OpenOrCreate))
                {
                    _userInfo = (UserInfo)serializer.Deserialize(fs);
                }
            }
        }

        private List<OrderInfo> GetOrderInfos ()
        {
            List<OrderInfo> orderInfos = new List<OrderInfo>(); ;
            XmlSerializer serializer = new XmlSerializer(typeof(List<OrderInfo>));
            if (File.Exists(OrderInfosFileName))
            {
                using (FileStream fs = new FileStream(OrderInfosFileName, FileMode.OpenOrCreate))
                {
                    orderInfos = (List<OrderInfo>)serializer.Deserialize(fs);
                }
            }
            return orderInfos;
        }

        private void BtnCreateObject_Click(object sender, RoutedEventArgs e)
        {
            ProjectSettings projectSettings = new ProjectSettings(UserInfo, OrderInfos);
            projectSettings.ShowDialog();
        }

        private void MiSettings_Click(object sender, RoutedEventArgs e)
        {
            UserSettings userSettings = new UserSettings();
            userSettings.ShowDialog();
        }

        private void BtnChangeObject_Click(object sender, RoutedEventArgs e)
        {
            ProjectSelectionWindow selectionWindow = new ProjectSelectionWindow(OrderInfos);
            selectionWindow.ShowDialog();
        }
    }
}
