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
    /// Interaction logic for UCVlc.xaml
    /// </summary>
    public partial class UCVlc : UserControl
    {
        public UCVlc()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string appPath=AppDomain.CurrentDomain.BaseDirectory;
           
        }
    }
}
