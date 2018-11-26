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


    public class CustomerComplaint
    {
        public String Logo { get; set; }
        public String JanStatus { get; set; }
        public String FebStatus { get; set; }
        public String MarStatus { get; set; }
        public String AprStatus { get; set; }
        public String MayStatus { get; set; }
        public String JunStatus { get; set; }
        public String JulStatus { get; set; }
        public String AugStatus { get; set; }
        public String SepStatus { get; set; }
        public String OctStatus { get; set; }
        public String NovStatus { get; set; }
        public String DecStatus { get; set; }
    }





    [ValueConversion(typeof(string), typeof(Image))]
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Image status = new Image() ;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                if (value.ToString() == "No")
                {
                    var urisource = new Uri("Images/HappySmiley.jpg", UriKind.Relative);
                    status.Source = new BitmapImage(urisource);
                }
                else if ((value.ToString() == "Yes"))
                {
                    var urisource = new Uri("Images/SadSmiley.jpg", UriKind.Relative);
                    status.Source = new BitmapImage(urisource);

                }

               
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
}
