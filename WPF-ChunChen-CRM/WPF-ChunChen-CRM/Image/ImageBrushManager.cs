using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_ChunChen_CRM.Image
{
    /// <summary>
    /// 图片资源管理器
    /// </summary>
    public class ImageBrushManager
    {
        /// <summary>
        /// 获取图片login_back
        /// </summary>
        /// <param name="stretch">图片填充类型</param>
        /// <returns></returns>
        public static ImageBrush Get_login_back(Stretch stretch = Stretch.UniformToFill)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + @"\Image\login_back.jfif"));
            imageBrush.Stretch = stretch;
            return imageBrush;
        }
    }
}
