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

namespace WPF_ChunChen_CRM.View.Employee
{
    /// <summary>
    /// EmployeeShow.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeShow : Page
    {
        public EmployeeShow()
        {
            InitializeComponent();
            //NavigationService.LoadCompleted += NavigationService_LoadCompleted;
        }

        public EmployeeShow(Guid employeeId)
        {
            InitializeComponent();
            UpdateEmployeeData(employeeId);
        }

        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        #region 参数

        #endregion

        #region 按钮
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeDefault());
        }
        #endregion

        #region 方法
        /// <summary>
        /// 更新用户个人信息
        /// </summary>
        private void UpdateEmployeeData(Guid employeeId)
        {
            UserViewModel userViewModel = employeeService.GetEmployeeData(employeeId);
            EmployeeNoValue.Content = userViewModel.EmployeeNo;
            NameValue.Content = userViewModel.Name;
            MobileValue.Content = userViewModel.Mobile;
            GenderStringValue.Content = userViewModel.GenderString;
            BirthdayValue.Content = userViewModel.Birthday?.ToString("yyyy-MM-dd");
            if (userViewModel.Quit)
            {
                JoinDateName.Text = "离职日期：";
                JoinDateValue.Content = userViewModel.QuitDate?.ToString("yyyy-MM-dd");
            }
            else
            {
                JoinDateName.Text = "入职日期：";
                JoinDateValue.Content = userViewModel.JoinDate.ToString("yyyy-MM-dd");
            }
        }
        #endregion

        #region 事件
        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            var data = (string)e.ExtraData;
            if (string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("未指定具体员工，将返回员工列表");
                NavigationService.Navigate(new EmployeeDefault());
            }
            Guid employeeId = Guid.Parse(e.ExtraData.ToString());
            UpdateEmployeeData(employeeId);
        }
        #endregion
    }
}
