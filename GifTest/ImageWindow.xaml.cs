using ImageMagick;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GifTest
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    { 
            
        public ImageWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // ShowGif();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btnHide.Content.ToString() == "Hide")
            {
                if (gd.Children.Count > 0 && gd.Children[0] is UserControl1 control1)
                {
                    control1.Clear();
                }
                if (gd.Children.Count > 0 && gd.Children[0] is UCMedia media)
                {
                    media.Clear();
                }
                if (gd.Children.Count > 0 && gd.Children[0] is UserControl3 media1)
                {
                    media1.Clear();
                }
                if (gd.Children.Count > 0 && gd.Children[0] is UserControl2 media2)
                {
                    media2.Clear();
                }
                gd.Children.Clear();
                btnHide.Content = "Show";
            }
            else
            {
                // UCMedia media=new UCMedia();
                 UserControl1 media = new UserControl1();
                //UserControl2 media = new UserControl2();
                //UserControl3 media = new UserControl3();
                gd.Children.Add(media);
                btnHide.Content = "Hide";
            }
        }
    }
}
