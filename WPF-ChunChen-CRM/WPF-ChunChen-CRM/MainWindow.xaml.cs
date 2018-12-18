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

namespace WPF_ChunChen_CRM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Avatar.Fill = Image.ImageBrushManager.Get_login_back(Stretch.UniformToFill);
            DefaultFarme.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            DefaultFarme.Navigate(new Uri("View/Personal/PersonalDefault.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dataGrid.ItemsSource = storeDB.Employee.ToList();
            //listView.ItemsSource = storeDB.Employee.ToList();
        }

        //点击个人信息
        private void PersonalMenu_Click(object sender, RoutedEventArgs e)
        {
            //DefaultFarme.Source = "page1.xaml";
            DefaultFarme.Navigate(new Uri("View/Personal/PersonalDefault.xaml", UriKind.Relative));
        }
    }
}
