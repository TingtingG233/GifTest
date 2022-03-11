using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using WpfAnimatedGif;

namespace GifTest
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        ImageAnimationController controller;
        List<BitmapImage> images=new List<BitmapImage>(new BitmapImage[1]);
        // bitmap;
        Stream stream;
        ImagePath imagePath { get; set; }=new ImagePath();
        public UserControl1()
        {
            InitializeComponent();
        }

        public  BitmapImage GetImage(string imagePath)
        {
            string file = imagePath;//System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "angles", $"{imagePath}");
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            stream = new MemoryStream(File.ReadAllBytes(file));
            bitmap.StreamSource = stream;
            bitmap.EndInit();
            // bitmap.Freeze();

            return bitmap;
        }

        private BitmapImage GetBitmapImage(string file)
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(file));
            FileInfo fileInfo = new FileInfo(file);
            byte[] buffer = reader.ReadBytes((int)fileInfo.Length);
            reader.Close();
            reader.Dispose();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit(); 
            bitmap.CacheOption = BitmapCacheOption.None;
            stream = new MemoryStream(buffer);
            bitmap.StreamSource = stream;
            bitmap.EndInit();
            bitmap.Freeze();
            media.DataContext = imagePath;
            imagePath.Path = bitmap;
            //using (Stream stream = new MemoryStream(File.ReadAllBytes(file)))
            //{
            //    bitmap.StreamSource = stream;
            //    bitmap.EndInit();
            //    bitmap.Freeze();
            //    media.DataContext = imagePath;
            //    imagePath.Path=bitmap;

            //}
            return bitmap;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImage();
        }

        private  void LoadImage()
        {
            images[0]=GetImage(".\\Images\\tibia_right.gif");
            ImageBehavior.SetAnimatedSource(media, images[0]);
            controller = ImageBehavior.GetAnimationController(media);
            controller.Pause();
            controller.GotoFrame(controller.FrameCount/2);
            PositiveProgress.Maximum = controller.FrameCount;

        }

        private void PositiveProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(controller==null)
            {
                controller = ImageBehavior.GetAnimationController(media);
                ImageBehavior.SetRepeatBehavior(media,new System.Windows.Media.Animation.RepeatBehavior(0));
                ImageBehavior.SetRepeatBehavior(media,System.Windows.Media.Animation.RepeatBehavior.Forever);
                controller.Pause();
                PositiveProgress.Maximum = controller.FrameCount;
            }
            int idx=(int)PositiveProgress.Value;
            if (idx < controller.FrameCount)
            {
                controller.GotoFrame(idx);
                GC.Collect();
            }
        }
        public async void Clear()
        {
            ImageBehavior.SetAnimatedSource(media, null);
            media.Source = null;
            GC.Collect();
            await Task.Run(() => {
                stream.Close();
                stream.Dispose();
                images.Clear();
                System.Threading.Thread.Sleep(1000);
                GC.Collect();
            });

        }
    }
}
