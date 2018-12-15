using ChunChen_CRM.IServices;
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
using System.Windows.Shapes;

namespace WPF_ChunChen_CRM
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            
            //设置背景图片
            this.Background = Image.ImageBrushManager.Get_login_back(Stretch.UniformToFill);
        }

        #region 窗体操作
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IAccountService accountService = new AccountService();
                string account = UserName.Text;
                string password = UserPassword.Password;
                if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("账号或密码为空");
                }
                if (accountService.Login(account, password))
                {
                    //MessageBox.Show("登录成功！");
                    //Application.Current.MainWindow.Show();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
