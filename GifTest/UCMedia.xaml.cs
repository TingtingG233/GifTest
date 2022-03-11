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

namespace GifTest
{
    /// <summary>
    /// Interaction logic for UCMedia.xaml
    /// </summary>
    public partial class UCMedia : UserControl
    {
        public UCMedia()
        {
            InitializeComponent();
        }
        private  void ShowGif()
        {
            media.Source = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "tibia_right.gif"));
            media.Play();
            // PositiveProgress.Maximum = media.NaturalDuration.TimeSpan.TotalMilliseconds;
            //await  Task.Run(() =>
            //{
            //    Dispatcher.Invoke(() =>
            //    {
            //        System.Threading.Thread.Sleep(300);
            //        media.Position = TimeSpan.FromMilliseconds(500);
            //        media.Play();
            //        System.Threading.Thread.Sleep(1);
            //        media.Pause();
            //    });
            //});
            }
        public Uri GetImagePath(string folder, string fileName)
        {
            return new Uri($"pack://application:,,,/{folder}/{fileName}");
        }

        private void PositiveProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = TimeSpan.FromMilliseconds((int)(PositiveProgress.Value/2.5));
            media.Play();
            System.Threading.Thread.Sleep(1);
            media.Pause();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           ShowGif();
        }
        public void Clear()
        {
            media.Source=null;
            GC.Collect();
        }
    }
}
