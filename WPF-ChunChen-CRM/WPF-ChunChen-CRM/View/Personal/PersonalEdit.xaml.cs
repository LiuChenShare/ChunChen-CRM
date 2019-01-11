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
        }

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

        }
    }
}
