using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace PlantStatusDisplay
{
    /// <summary>
    /// Interaction logic for CustomerComplaintStatus.xaml
    /// </summary>
    public partial class CustomerComplaintStatus : UserControl
    {
        public CustomerComplaintStatus()
        {
            InitializeComponent();
        }
    }


   





    [ValueConversion(typeof(string), typeof(Image))]
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Image status = new Image() ;
            if (string.IsNullOrEmpty((string)value))
            {
                return status;
            }
            else if (value.ToString() == "No")
            {
                var urisource = new Uri("Images/HappySmiley.jpg", UriKind.Relative);
                status.Source = new BitmapImage(urisource);
            }
            else if ((value.ToString() == "Yes"))
            {
                var urisource = new Uri("Images/SadSmiley.jpg", UriKind.Relative);
                status.Source = new BitmapImage(urisource);

            }

               
            
            status.Width = 40;
            status.Height = 40;
            return status;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(string), typeof(Image))]
    public class NameToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Image status = new Image();
            if (string.IsNullOrEmpty((string)value))
            {
                return status;
            }
              var urisource = new Uri("Images/"+value.ToString()+".png", UriKind.Relative);
                status.Source = new BitmapImage(urisource);
           



           
            return status;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
