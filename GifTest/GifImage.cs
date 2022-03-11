using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace GifTest
{
    internal class GifImage : System.Windows.Controls.Image
    {
        private Bitmap bitmap;

        private BitmapSource bitmapSource;

        public GifImage(string path)
        {
            bitmap = new Bitmap(path);
            GetBitmapSource(bitmap);
        }

        private BitmapSource GetBitmapSource(Bitmap _bitmap)
        {
            IntPtr intPtr = IntPtr.Zero;
            try
            {
                intPtr=bitmap.GetHbitmap();
                bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(intPtr, IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if(intPtr != IntPtr.Zero)
                {
                    DeleteObject(intPtr);
                }
            }
            return bitmapSource;
        }

        private void GotoFrame()
        {
            ImageAnimator.UpdateFrames();
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DeleteObject(IntPtr hObject);
    }
}
