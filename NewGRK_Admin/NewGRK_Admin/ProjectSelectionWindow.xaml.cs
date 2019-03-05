using System;
using System.Collections.Generic;
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

namespace NewGRK_Admin
{
    /// <summary>
    /// Логика взаимодействия для OrderSelectionWindow.xaml
    /// </summary>
    public partial class ProjectSelectionWindow : Window
    {
        private enum ListItemType { Object = 0, Project = 1 }

        private ListItemType itemType = ListItemType.Object;

        private readonly List<OrderInfo> _orderInfos;

        private List<OrderInfo> OrderInfos => _orderInfos;
        public ProjectSelectionWindow(List<OrderInfo> orderInfos)
        {
            InitializeComponent();
            _orderInfos = orderInfos;
            LoadOrderInfos();

            //lbGRKType.SelectionChanged += LbGRKType_SelectionChanged;

        }

        private void LoadOrderInfos ()
        {
            if (OrderInfos.Count > 0)
            {
                foreach (OrderInfo order in OrderInfos)
                {
                    lbOrders.Items.Add(order);
                }
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            OrderInfo order = lbOrders.SelectedValue as OrderInfo;
            ServerInfo serverInfo = order.ServerInfo;
            IGRK_DB _DB = null;
            GRK_DBType dbType = serverInfo.GRK_DBType;
            switch (dbType)
            {
                case GRK_DBType.MSSQL:
                    _DB = new MSSQL_DB(serverInfo.ServerName,serverInfo.DBName, serverInfo.Login, serverInfo.Password);
                    break;
                case GRK_DBType.Postgres:
                    _DB = new PostgreSQL_DB(serverInfo.ServerName, serverInfo.DBName, serverInfo.Login, serverInfo.Password); ;
                    break;
            }
            ProjectWindow project = new ProjectWindow(_DB, order, CurrentOperation.Edit);
            project.Show();
            this.Close();
            
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selInd = (sender as ComboBox).SelectedIndex;
            itemType = (ListItemType)selInd;


        }



        /*private void LbGRKType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }*/
    }
}
