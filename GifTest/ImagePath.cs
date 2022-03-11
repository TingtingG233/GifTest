using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GifTest
{
    internal class ImagePath : INotifyPropertyChanged
    {
        private BitmapImage _imagePath;
        public BitmapImage Path { get => _imagePath; set { _imagePath = value;OnPropertyChanged("Path"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
