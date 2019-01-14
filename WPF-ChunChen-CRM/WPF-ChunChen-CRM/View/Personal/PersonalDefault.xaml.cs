using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using ChunChen_CRM.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_ChunChen_CRM.View.Personal
{
    /// <summary>
    /// 用户个人页面
    /// PersonalDefault.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalDefault : Page
    {
        public PersonalDefault()
        {
            InitializeComponent();
            UpdateUserPersonalData();
        }


        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        #region 参数

        #endregion

        #region 按钮
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/Personal/PersonalEdit.xaml", UriKind.Relative));
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            //this.ma.PersonalFarme.Navigate(new Uri("View/Personal/PersonalDefault.xaml", UriKind.Relative));
        }
        #endregion

        #region 方法
        /// <summary>
        /// 更新用户个人信息
        /// </summary>
        private void UpdateUserPersonalData()
        {
            UserViewModel userViewModel = employeeService.GetPersonalData();
            EmployeeNoValue.Content = userViewModel.EmployeeNo;
            NameValue.Content = userViewModel.Name;
            MobileValue.Content = userViewModel.Mobile;
            GenderStringValue.Content = userViewModel.Mobile;
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

    }
}
