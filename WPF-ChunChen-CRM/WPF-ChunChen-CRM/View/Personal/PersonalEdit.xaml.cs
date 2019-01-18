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
    /// PersonalEdit.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalEdit : Page
    {
        public PersonalEdit()
        {
            InitializeComponent();
            UpdateUserPersonalData();
        }

        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("点击了");
            NavigationService.Navigate(new Uri("View/Personal/PersonalEdit.xaml", UriKind.Relative));
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/Personal/PersonalDefault.xaml", UriKind.Relative));
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/Personal/PersonalDefault.xaml", UriKind.Relative));
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.Mobile = MobileValue.Text.ToString();
                userViewModel.Gender = 0;
                if (GenderStringValue.Text == "男")
                {
                    userViewModel.Gender = 1;
                }
                userViewModel.Birthday = BirthdayValue.DateTime;
                if (employeeService.SavePersonalData(userViewModel))
                {
                    NavigationService.Navigate(new Uri("View/Personal/PersonalDefault.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show(Window.GetWindow(this), "更新失败");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Window.GetWindow(this), ex.Message);
            }
        }

        #region 方法
        /// <summary>
        /// 加载用户个人信息
        /// </summary>
        private void UpdateUserPersonalData()
        {
            UserViewModel userViewModel = employeeService.GetPersonalData();
            EmployeeNoValue.Content = userViewModel.EmployeeNo;
            NameValue.Content = userViewModel.Name;
            MobileValue.Text = userViewModel.Mobile;
            if(userViewModel.Gender != 0)
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
