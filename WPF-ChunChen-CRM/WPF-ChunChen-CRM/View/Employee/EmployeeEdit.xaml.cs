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
    /// 员工信息编辑页面
    /// </summary>
    public partial class EmployeeEdit : Page
    {
        public EmployeeEdit()
        {
            InitializeComponent();
        }

        public EmployeeEdit(Guid employeeId)
        {
            InitializeComponent();
            UpdateEmployeeData(employeeId);
        }

        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        #region 参数
        UserViewModel userViewModel = new UserViewModel();
        #endregion

        #region 按钮
        //返回上一页
        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeDefault());
        }

        //确认
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameValue.Text))
                {
                    throw new Exception("请输入姓名");
                }
                if (string.IsNullOrWhiteSpace(MobileValue.Text))
                {
                    throw new Exception("请输入手机号");
                }
                
                userViewModel.Name = NameValue.Text;
                userViewModel.Mobile = MobileValue.Text.ToString();
                userViewModel.Gender = 0;
                if (GenderStringValue.Text == "男")
                {
                    userViewModel.Gender = 1;
                }
                userViewModel.Birthday = BirthdayValue.DateTime;
                if (employeeService.UpdateEmployeeData(userViewModel))
                {
                    MessageBox.Show(Window.GetWindow(this), "修改成功");
                    NavigationService.Navigate(new EmployeeShow(userViewModel.Id));
                }
                else
                {
                    MessageBox.Show(Window.GetWindow(this), "更新失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Window.GetWindow(this), "更新失败：" + ex.Message);
            }
        }

        //取消
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeShow(userViewModel.Id));
        }
        #endregion

        #region 方法
        /// <summary>
        /// 加载用户个人信息
        /// </summary>
        private void UpdateEmployeeData(Guid employeeId)
        {
            userViewModel = employeeService.GetEmployeeData(employeeId);
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


    }
}
