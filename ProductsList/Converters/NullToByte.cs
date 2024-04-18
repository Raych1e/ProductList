using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ProductsList.Converters
{
    public class NullToByte :IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo info)
        {
            if (value == null)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"\Images\picture.png", UriKind.Relative);
                bitmap.EndInit();
                return bitmap;
            }
            return value;
        }

        public object ConvertBack(object value, Type type, object parameter, CultureInfo info)
        {
            return null;
        }
    }
}
