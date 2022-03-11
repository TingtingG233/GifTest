using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        List<BitmapImage> bitmapImages = new List<BitmapImage>(new BitmapImage[31]);
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImages();
        }

        private void LoadImages()
        {
            for(int i=0;i<31;i++)
            {
                bitmapImages[i] = GetImage($"{i - 15}.png");//GetImage(GetImagePath("angles",$"{i-15}.png"));
            }
            
        }
        //public  string  GetImagePath(string folder, string fileName)
        //{
        //    return $"pack://application:,,,/{folder}/{fileName}";
        //}
        //public static BitmapImage GetImg(Uri url)
        //{
           
        //    try
        //    {
        //        BitmapImage image = new BitmapImage();
        //        image.BeginInit();
        //        image.CacheOption = BitmapCacheOption.OnLoad;
        //        image.UriSource = url;
        //        image.EndInit();
        //        image.Freeze();
        //        return image;
        //    }
        //    catch (Exception ex)
        //    {
        //        //App.Logger.Debug(ex.Message);
        //    }
        //    return null;
        //}

        public static BitmapImage GetImage(string imagePath)
        {
            string file =System.IO.Path.Combine("angles", $"{imagePath}");
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            using (Stream ms = new MemoryStream(File.ReadAllBytes(file)))
            {
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                bitmap.Freeze();
            }
            return bitmap;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            img.Source=bitmapImages[(int)e.NewValue+15];
        }

        public void Clear()
        {
            img.Source = null;
            bitmapImages.Clear();
            //System.Threading.Thread.Sleep(1000);
            GC.Collect();
            //await Task.Run(() =>
            //{
            //    bitmapImages.Clear();
            //    System.Threading.Thread.Sleep(1000);
            //    GC.Collect();
            //});

        }
    }
}
