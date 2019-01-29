using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using ChunChen_CRM.Model.Search;
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
    /// EmployeeDefault.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeDefault : Page
    {
        public EmployeeDefault()
        {
            InitializeComponent();
            //NavigationService.LoadCompleted += NavigationService_LoadCompleted;
            ListUpdate();
        }

        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        public List<UserViewModel> userViews = new List<UserViewModel>();
        

        public void ListUpdate()
        {
            EmployeeSearch search = new EmployeeSearch();
            userViews = employeeService.SearchEmployeeList(search);
            EmployeeList.Items.Clear();  //只移除所有的项。
            for(int i = 0; i < userViews.Count(); i++)
            {
                userViews[i].Index = i + 1;
                this.EmployeeList.Items.Add(userViews[i]);
            }
            
        }

        /// <summary>
        /// 点击删除按钮
        /// </summary>
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("暂无删除功能！");
        }

        /// <summary>
        /// 点击列表某行
        /// </summary>
        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.NavigationService.Navigate(new ContentPage(), DateTime.Now);
        }

        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            DateTime requestDateTime = (DateTime)e.ExtraData;
            string msg = string.Format("Request started {0}\nRequest completed {1}", requestDateTime, DateTime.Now);
            MessageBox.Show(msg);
        }
    }
}
