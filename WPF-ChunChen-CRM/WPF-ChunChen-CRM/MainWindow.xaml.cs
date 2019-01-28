using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using ChunChen_CRM.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ChunChen_CRM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Avatar.Fill = Image.ImageBrushManager.Get_login_back(Stretch.UniformToFill);
            PersonalFarme.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            PersonalFarme.Navigate(new Uri("View/Personal/PersonalDefault.xaml", UriKind.Relative));
            PersonalFarme.Visibility = Visibility.Visible;
            UpdateUserPersonalData();
        }

        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dataGrid.ItemsSource = storeDB.Employee.ToList();
            //listView.ItemsSource = storeDB.Employee.ToList();
        }
        
        //点击个人信息
        private void PersonalMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseFarme();
            PersonalFarme.Visibility = Visibility.Visible;
        }

        //点击客户管理
        private void CustomerMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseFarme();
            CustomerFarme.Visibility = Visibility.Visible;
        }

        //点击员工管理
        private void EmployeeMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseFarme();
            EmployeeFarme.Visibility = Visibility.Visible;
        }

        //点击订单管理
        private void OrderMenu_Click(object sender, RoutedEventArgs e)
        {
            CloseFarme();
            OrderFarme.Visibility = Visibility.Visible;
        }

        #region Farme页方法
        private void CloseFarme()
        {
            PersonalFarme.Visibility = Visibility.Collapsed;
            CustomerFarme.Visibility = Visibility.Collapsed;
            EmployeeFarme.Visibility = Visibility.Collapsed;
            OrderFarme.Visibility = Visibility.Collapsed;
        }
        #endregion

        /// <summary>
        /// 加载用户个人信息
        /// </summary>
        private void UpdateUserPersonalData()
        {
            UserViewModel userViewModel = employeeService.GetPersonalData();
            Welcome.Content = "欢迎" + userViewModel.Name;
        }
    }
}
