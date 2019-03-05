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
    public enum CurrentOperation { Create, Edit }
    /// <summary>
    /// Логика взаимодействия для ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        private readonly OrderInfo _orderInfo;
        private readonly IGRK_DB _dB;
        private readonly CurrentOperation _currentOperation;
        private int _gRK_ID;

        private OrderInfo OrderInfo => _orderInfo;
        private IGRK_DB DB => _dB;
        private CurrentOperation CurrentOperation => _currentOperation;

        private int GRK_ID { get => GetGRK_ID(); set => SetGRK_ID(value); }

        private int GetGRK_ID()
        {
            _gRK_ID = (int)spinGRK_ID.Value;
            return _gRK_ID;
        }

        private void SetGRK_ID(int value)
        {
            spinGRK_ID.Value = value;
            _gRK_ID = value;
        }

        public ProjectWindow(IGRK_DB db, OrderInfo orderInfo, CurrentOperation operation)
        {
            _orderInfo = orderInfo;
            _dB = db;
            _currentOperation = operation;

            InitializeComponent();

            switch (operation)
            {
                case CurrentOperation.Create:
                    LoadNewObject();
                    break;
                case CurrentOperation.Edit:
                    LoadExistingObject();
                    break;
            }

            LoadParents();
            
        }

        private void LoadParents()
        {
            lbParentsList.ItemsSource = DB.GetObjectTypes();
        }

        private void LoadNewObject()
        {
            SetNewID();
        }

        private void LoadExistingObject()
        {
            LockControls();
        }

        private void LockControls()
        {
            txtName.IsEnabled = false;
            txtUID.IsEnabled = false;
        }

        private void SetNewID()
        {
            spinGRK_ID.Value = DB.GetLastID() + 1;
        }

        private void BtnUIDGen_Click(object sender, RoutedEventArgs e)
        {
            Guid guid = Guid.NewGuid();
            txtUID.Text = guid.ToString();
        }
    }
}
