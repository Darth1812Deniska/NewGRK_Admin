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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Path = System.IO.Path;

namespace NewGRK_Admin
{
    /// <summary>
    /// Логика взаимодействия для ProjectSettings.xaml
    /// </summary>
    public partial class ProjectSettings : Window
    {
        private IGRK_DB DB;
        private UserInfo UserInfo;
        private List<ServerInfo> serverInfos;

        private const string ServerInfosFileName = "GRK_ServerInfos.xml";
        
        private string ServerName { get => GetServerName(); }
        private string DataBaseName { get => GetDataBaseName(); }
        private GRK_DBType GRK_DBType { get => GetGRK_DBType(); }
        private string Login { get => GetLogin(); }
        private string Password { get => GetPassword(); }

        private OrderType OrderType { get => GetOrderType(); }
        private string OrderNum { get => GetOrderNum(); }
        private string OrderName { get =>GetOrderName(); }

        private string GetServerName()
        {
            string serverName = cmbServerName.Text;
            if (cmbServerName.SelectedIndex != -1)
            {
                serverName = cmbServerName.SelectedItem.ToString();
            }
            return serverName;
        }

        private string GetDataBaseName()
        {
            string dataBaseName = txtDBName.Text;
            return dataBaseName;
        }

        private GRK_DBType GetGRK_DBType()
        {
            GRK_DBType _DBType;
            _DBType = (GRK_DBType)cmbServerType.SelectedIndex;
            return _DBType;
        }

        private string GetLogin()
        {
            string login;
            login = txtLogin.Text;
            return login;
        }

        private string GetPassword()
        {
            string password;
            password = psbPassword.Password;
            return password;
        }

        private OrderType GetOrderType()
        {
            OrderType orderType = (rbChange.IsChecked == true) ? OrderType.Change : OrderType.Problem;
            return orderType;
        }

        private string GetOrderNum()
        {
            return txtOrderNum.Text;
        }

        private string GetOrderName()
        {
            return txtOrderName.Text;
        }

        public ProjectSettings(UserInfo userInfo)
        {
            InitializeComponent();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ServerInfo>));
            if (File.Exists(ServerInfosFileName))
            {
                using (FileStream fs = new FileStream(ServerInfosFileName, FileMode.OpenOrCreate))
                {
                    serverInfos = (List<ServerInfo>)serializer.Deserialize(fs);
                }
            }
            else
            {
                serverInfos = new List<ServerInfo>();
            }

            cmbServerType.SelectionChanged += CmbServerType_SelectionChanged;
            cmbServerType.SelectedIndex = 0;

            UserInfo = userInfo;

            if (cmbServerType.SelectedIndex == -1)
            {
                BlockServerInfoControls();
            }
        }

        private void BtnTestConnection_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbServerType.Text))
            {
                string serverName;
                string dbName;
                string login;
                string password;

                bool isServerNameNotEmpty = false;
                bool isDBNameNotEmpty = false;
                bool isLoginNotEmpty = false;
                bool isPasswordNotEmpty = false;

                serverName = CheckField(ServerName, out isServerNameNotEmpty);
                dbName = CheckField(DataBaseName, out isDBNameNotEmpty);
                login = CheckField(Login, out isLoginNotEmpty);
                password = CheckField(Password, out isPasswordNotEmpty);

                if (isServerNameNotEmpty && isDBNameNotEmpty && isLoginNotEmpty && isPasswordNotEmpty)
                {
                    GRK_DBType dbType = (GRK_DBType)cmbServerType.SelectedIndex;
                    switch (dbType)
                    {
                        case GRK_DBType.MSSQL:
                            DB = new MSSQL_DB(serverName, dbName, login, password);
                            break;
                        case GRK_DBType.Postgres:
                            DB = new PostgreSQL_DB(serverName, dbName, login, password);
                            break;
                    }

                    if (DB.TestConnection())
                    {
                        ServerInfo serverInfo = new ServerInfo(DB.ServerName, DB.GRK_DBType, DB.DataBaseName, DB.Login, DB.Password);
                        SaveServerToXML(serverInfo);
                        MessageBox.Show("Успешно");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось подключиться к БД");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните параметры для подключения");
                }
            }
            else
            {
                MessageBox.Show($"Выберите тип БД");
            }

        }

        private string CheckField (string inputString, out bool isNotEmpty)
        {
            string outputString = String.Empty;
            if (!String.IsNullOrEmpty(inputString.Trim()))
            {
                outputString = inputString.Trim();
                isNotEmpty = true;
            }
            else
            {
                isNotEmpty = false;
            }
            return outputString;
        }

        private void SaveServerToXML(ServerInfo serverInfo)
        {
            if (!serverInfos.Contains(serverInfo))
            {
                serverInfos.Add(serverInfo);
            }
            else
            {
                var tmpServerInfo = serverInfos.Find(x => x.ServerName == serverInfo.ServerName);
                serverInfos.Remove(tmpServerInfo);
                serverInfos.Add(serverInfo);
            }
            XmlSerializer serializer = new XmlSerializer(serverInfos.GetType());

            try
            {
                using (FileStream fs = new FileStream(ServerInfosFileName, FileMode.Create))
                {
                    serializer.Serialize(fs, serverInfos);
                }
            }
            catch
            {
                MessageBox.Show($"Ошибка при создании {ServerInfosFileName}");
            }
        }

        private void CmbServerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selIndex = (sender as ComboBox).SelectedIndex;
            if (selIndex == -1)
            {
                BlockServerInfoControls();
            }
            else
            {
                if (serverInfos != null)
                {
                    var dbServList = serverInfos.FindAll(x => x.GRK_DBType == GRK_DBType);
                    cmbServerName.ItemsSource = dbServList.Select(x => x.ServerName).ToList();
                    UnblockServerInfoControls();
                }
            }
        }

        private void BlockServerInfoControls()
        {
            cmbServerName.IsEnabled = false;
            txtDBName.IsEnabled = false;
            txtLogin.IsEnabled = false;
            psbPassword.IsEnabled = false;
            btnTestConnection.IsEnabled = false;
        }

        private void UnblockServerInfoControls()
        {
            cmbServerName.IsEnabled = true;
            txtDBName.IsEnabled = true;
            txtLogin.IsEnabled = true;
            psbPassword.IsEnabled = true;
            btnTestConnection.IsEnabled = true;
        }

        private void CmbServerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selIndex = (sender as ComboBox).SelectedIndex;
            if (selIndex == -1)
            {
                txtLogin.Text = String.Empty;
                txtDBName.Text = String.Empty;
                psbPassword.Password = String.Empty;
            }
            else
            {
                var selSerInfo = serverInfos.Find(x => x.ServerName == (sender as ComboBox).SelectedItem.ToString());
                txtLogin.Text = selSerInfo.Login;
                txtDBName.Text = selSerInfo.DBName;
                psbPassword.Password = selSerInfo.Password;
            }
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            //string test = new String(Path.GetInvalidFileNameChars().ToArray());
            ////MessageBox.Show(test);
            //test = new String(Path.GetInvalidPathChars().ToArray());
            //MessageBox.Show(test);

            

            ServerInfo serverInfo = new ServerInfo(ServerName, GRK_DBType, DataBaseName, Login, Password);
            OrderInfo orderInfo = new OrderInfo(OrderNum, OrderName, OrderType, serverInfo, UserInfo);
            MessageBox.Show($"{orderInfo.FullOrderName}, {orderInfo.FullOrderNum}, {orderInfo.OrderDirectory}, " +
                $"{orderInfo.OrderName}, {orderInfo.OrderNum}, " +
                $"{orderInfo.OrderType}, {orderInfo.SQLFileFullName}, {orderInfo.SQLFileName}");

        }
    }
}
