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
            SizeChanged += new System.Windows.SizeChangedEventHandler(Page_Resize);
        }



        #region 服务
        private IEmployeeService employeeService = new EmployeeService();
        #endregion

        public IPageList<UserViewModel> userViews = new PageList<UserViewModel>();
        public EmployeeSearch search = new EmployeeSearch();


        public void ListUpdate()
        {
            userViews = employeeService.SearchEmployeeList(search);
            EmployeeList.Items.Clear();  //只移除所有的项。
            for (int i = 0; i < userViews.Data.Count(); i++)
            {
                userViews.Data[i].Index = i + 1;
                EmployeeList.Items.Add(userViews.Data[i]);
            }
            Index.Content = string.Format("{0} / {1}", userViews.PageIndex + 1, userViews.TotalPage);
            if (userViews.PageIndex == 0)
            {
                PreviousPageButton.IsEnabled = false;
            }
            //if (userViews.PageIndex >= userViews.TotalPage - 1)
            //{
            //    NextPageButton.IsEnabled = false;
            //}
        }
        #region 界面按钮

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
        
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (search.Index < userViews.TotalPage - 1)
            {
                search.Index++;
                ListUpdate();
            }
        }
        #endregion

        #region 事件

        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            DateTime requestDateTime = (DateTime)e.ExtraData;
            string msg = string.Format("Request started {0}\nRequest completed {1}", requestDateTime, DateTime.Now);
            MessageBox.Show(msg);
        }

        /// <summary>
        /// 窗体大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Resize(object sender, SizeChangedEventArgs e)
        {
            //调整列宽
            if (EmployeeList.View is GridView gv)
            {
                for (int i = 0; i < gv.Columns.Count; i++)
                {
                    var gvc = gv.Columns[i];
                    double width = 0;
                    if (i == 0)
                    {
                        width = (e.NewSize.Width - 100) * 0.08;
                    }
                    else if (i == gv.Columns.Count - 1)
                    {
                        width = 90;
                    }
                    else
                    {
                        width = (e.NewSize.Width - 100) * 0.23;
                    }
                    gvc.Width = width;
                }
                //foreach (GridViewColumn gvc in gv.Columns)
                //{
                //    gvc.Width = gvc.ActualWidth;
                //    gvc.Width = Double.NaN;
                //}
            }

        }

        #endregion

    }
}
