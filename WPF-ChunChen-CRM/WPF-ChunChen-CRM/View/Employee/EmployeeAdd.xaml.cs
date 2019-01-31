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
using WPF_ChunChen_CRM.Code;

namespace WPF_ChunChen_CRM.View.Employee
{
    /// <summary>
    /// EmployeeAdd.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeAdd : Page
    {
        public EmployeeAdd()
        {
            InitializeComponent();
        }

        #region 服务
        private IEmployeeService employeeService = new EmployeeService();

        #endregion

        #region 界面功能
        //确认
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(AccountValue.Text))
                {
                    throw new Exception("请输入账号");
                }
                if (string.IsNullOrWhiteSpace(PasswordValue.Text))
                {
                    throw new Exception("请输入预设密码");
                }
                if (string.IsNullOrWhiteSpace(NameValue.Text))
                {
                    throw new Exception("请输入姓名");
                }
                if (string.IsNullOrWhiteSpace(MobileValue.Text))
                {
                    throw new Exception("请输入手机号");
                }

                UserViewModel userViewModel = new UserViewModel();
                userViewModel.Account = AccountValue.Text;
                userViewModel.Password = PasswordValue.Text;
                userViewModel.Name = NameValue.Text;
                userViewModel.Mobile = MobileValue.Text.ToString();
                userViewModel.Gender = 0;
                if (GenderStringValue.Text == "男")
                {
                    userViewModel.Gender = 1;
                }
                userViewModel.Birthday = BirthdayValue.DateTime;
                userViewModel.JoinDate = JoinDateValue.DateTime;
                if (employeeService.SaveEmployeeData(userViewModel))
                {
                    MessageBox.Show(Window.GetWindow(this), "添加成功");
                    //NavigationService.Navigate();
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
            NavigationService.Navigate(new EmployeeDefault(), Guid.NewGuid());
        }

        //返回
        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeDefault(), Guid.NewGuid());
        }
        #endregion

        #region 事件
        //输入文本事件
        private void tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            PreviewTextInputMonitor previewTextInputMonitor = new PreviewTextInputMonitor();
            previewTextInputMonitor.tb_PreviewTextInput(sender, e);
        }
        #endregion
    }
}
