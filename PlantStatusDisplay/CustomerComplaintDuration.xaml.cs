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
    /// Interaction logic for CustomerComplaintDurationD.xaml
    /// </summary>
    public partial class CustomerComplaintDuration : UserControl
    {
        public CustomerComplaintDuration(DateTime lastCustomerComplaint)
        {
            InitializeComponent();

            LastComplaintTextBlock.Text = lastCustomerComplaint.ToString("dd/MMM/yyyy");
            TodayDateTextBlock.Text = DateTime.Now.ToString("dd/MMM/yyyy");

            DaysTextBlock.Text = (DateTime.Now - lastCustomerComplaint).Days.ToString();
        }
    }
}
