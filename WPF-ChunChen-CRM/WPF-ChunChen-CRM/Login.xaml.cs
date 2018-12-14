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
            
            ImageBrush b = new ImageBrush();
            b.ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory()+ @"\Image\login_back.jfif"));
            b.Stretch = Stretch.Fill;
            this.Background = b;
        }
    }
}
