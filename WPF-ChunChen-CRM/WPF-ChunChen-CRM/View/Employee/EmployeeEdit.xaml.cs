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
    /// EmployeeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeEdit : Page
    {
        public EmployeeEdit()
        {
            InitializeComponent();
        }

        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        //返回上一页
        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeDefault());
        }

        #region 方法
        /// <summary>
        /// 加载用户个人信息
        /// </summary>
        private void UpdateUserPersonalData()
        {
            UserViewModel userViewModel = employeeService.GetPersonalData();
            EmployeeNoValue.Content = userViewModel.EmployeeNo;
            NameValue.Text = userViewModel.Name;
            MobileValue.Text = userViewModel.Mobile;
            if (userViewModel.Gender != 0)
            {
                GenderStringValue_Man.IsSelected = true;
                //GenderStringValue_Woman.IsSelected = false;
            }
            if (userViewModel.Birthday.HasValue)
            {
                BirthdayValue.SetDateTime(userViewModel.Birthday.Value);
            }
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

        //确认
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //取消
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
