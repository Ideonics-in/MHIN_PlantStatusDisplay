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

namespace PlantStatusDisplay
{
    /// <summary>
    /// Interaction logic for AccidentDurationDisplay.xaml
    /// </summary>
    public partial class AccidentDurationDisplay : UserControl
    {
        public AccidentDurationDisplay(DateTime lastAccidentDate )
        {
            InitializeComponent();
            LastAccidentDateTextBlock.Text = lastAccidentDate.ToString("dd/MMM/yyyy");
            TodayDateTextBlock.Text = DateTime.Now.ToString("dd/MMM/yyyy");

            DaysTextBlock.Text = (DateTime.Now - lastAccidentDate).Days.ToString();
        }
    }
}
