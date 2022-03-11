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
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.IO;

namespace GifTest
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        List<BitmapFrame> frames = new List<BitmapFrame>();
        public UserControl2()
        {
            InitializeComponent();
        }

        private void GetBitmapImage(Uri file)
        {
            frames.Clear();

            GifBitmapDecoder decoder = new GifBitmapDecoder(file,BitmapCreateOptions.PreservePixelFormat,BitmapCacheOption.OnLoad);
            if(decoder!=null&&decoder.Frames!=null)
            {
                frames.AddRange(decoder.Frames);
                frames[0].Freeze();
                media.Source = frames[frames.Count/2];
                PositiveProgress.Maximum = frames.Count;
            }
           
        }

        private void GetBitmapImage(string file)
        {
            frames.Clear();
            string path  = System.IO.Path.Combine("Images", $"{file}");
            using (Stream ms = new MemoryStream(File.ReadAllBytes(path)))
            {
                GifBitmapDecoder decoder = new GifBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                if (decoder != null && decoder.Frames != null)
                {
                    frames.AddRange(decoder.Frames);
                    frames[0].Freeze();
                    media.Source = frames[frames.Count / 2];
                    PositiveProgress.Maximum = frames.Count;
                }
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImage();
        }

        private void LoadImage()
        {
            // GetBitmapImage(GetImagePath("Images","tibia_right.gif"));

            GetBitmapImage("tibia_right.gif");
        }

        private void PositiveProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int idx = (int)PositiveProgress.Value;
            if (idx == frames.Count)
                idx--;
            media.Source = frames[idx];
        }

        public static Uri GetImagePath(string folder, string fileName)
        {
            return new Uri($"pack://application:,,,/{folder}/{fileName}");
        }
        public void Clear()
        {
            media.Source = null;
            frames.Clear();
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
