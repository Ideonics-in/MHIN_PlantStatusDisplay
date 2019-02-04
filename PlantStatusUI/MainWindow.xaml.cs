using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PlantStatusUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MonthlyStat> MonthlyStats;

        ObservableCollection<Inventory> Inventory;
        ObservableCollection<Labour> Labour;
        ObservableCollection<CustomerComplaint> CustomerComplaints;

        Dictionary<String, Event> EventDictionary;
        public MainWindow()
        {
            InitializeComponent();

            MonthlyStats = new ObservableCollection<MonthlyStat>();
            
            EventDictionary = new Dictionary<string, Event>();

            CustomerComplaints = new ObservableCollection<CustomerComplaint>();

            using (var db = new PSDB())
            {
                var stats = from s in db.MonthlyStats
                            where s.Year == DateTime.Now.Year
                            select s;
                var events = from e in db.Events
                             select e;

                var complaints = db.CustomerComplaints.ToList();

                foreach(MonthlyStat m in stats)
                {
                    MonthlyStats.Add(m);
                    
                }

                foreach(Event e in events)
                {
                    EventDictionary.Add(e.Tag, e);

                }
                if(EventDictionary["LastAccidentDate"].Timestamp != null)
                    AccidentDatePicker.SelectedDate = EventDictionary["LastAccidentDate"].Timestamp.Value;

                if(EventDictionary["CustomerComplaintDate"].Timestamp != null)
                    CustomerComplaintDatePicker.SelectedDate = EventDictionary["CustomerComplaintDate"].Timestamp.Value;

                foreach (CustomerComplaint c in complaints)
                {
                    CustomerComplaints.Add(c);

                }



                StatsDataGrid.DataContext = MonthlyStats;
                    ComplaintsGrid.DataContext = CustomerComplaints;
                Inventory = new ObservableCollection<Inventory>();
                Labour = new ObservableCollection<Labour>();
            }
        }

        private void UpdateStatsButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PSDB())
            {
                EventDictionary["CustomerComplaintDate"].Timestamp = CustomerComplaintDatePicker.SelectedDate;
                EventDictionary["LastAccidentDate"].Timestamp = AccidentDatePicker.SelectedDate;
                foreach (var m in MonthlyStats)
                {
                    // try to retrieve existing entity
                    var ms = db.MonthlyStats.Find(m.ID);

                    ms.Inventory_Actual = m.Inventory_Actual;
                    ms.Inventory_Average = m.Inventory_Average;
                    ms.Inventory_Target = m.Inventory_Target;

                    ms.LPC_Actual = m.LPC_Actual;
                    ms.LPC_Target = m.LPC_Target;

                    ms.NQC_Actual = m.NQC_Actual;
                    ms.NQC_Target = m.NQC_Target;

                    ms.OEE_Actual = m.OEE_Actual;
                    ms.OEE_Target = m.OEE_Target;

                }

                foreach(Event ev in EventDictionary.Values)
                {
                    var eve = db.Events.Find(ev.ID);
                    eve.Timestamp = ev.Timestamp;


                }

                db.SaveChanges();

                MessageBox.Show("Update Complete", "Update Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void UpdateLabourButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(BaseTabControl.SelectedIndex == 1)
            {
                CurrentDatePicker.SelectedDate = DateTime.Now;
                Inventory.Clear();
                Labour.Clear();
                InventoryDataGrid.DataContext = Inventory;
                LabourEffDataGrid.DataContext = Labour;
            }
        }

        private void LabourEfficiencyButton_Click(object sender, RoutedEventArgs e)
        {
            Labour.Add(new DataAccess.Entity.Labour());

        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            Inventory.Add(new DataAccess.Entity.Inventory());
        }

        private void UpdateCustomerComplaintsButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PSDB())
            {
                foreach (var c in CustomerComplaints)
                {
                    var ms = db.CustomerComplaints.Find(c.CustomerComplaintID);
                    if (ms == null) continue;

                    ms.Jan = c.Jan;
                    ms.Feb = c.Feb;
                    ms.Mar = c.Mar;
                    ms.Apr = c.Apr;
                    ms.May = c.May;
                    ms.Jun = c.Jun;
                    ms.Jul = c.Jul;
                    ms.Aug = c.Aug;
                    ms.Sep = c.Sep;
                    ms.Oct = c.Oct;
                    ms.Nov = c.Nov;
                    ms.Dec = c.Dec;
                }

                db.SaveChanges();
                MessageBox.Show("Update Complete", "Update Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
    [ValueConversion(typeof(string), typeof(Boolean?))]
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (string.IsNullOrEmpty((string)value))
            {
                return null;
            }
            else if (value.ToString() == "No")
                return false;

            else if ((value.ToString() == "Yes"))
            {
                return true;

            }
            else return null;


           
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Boolean? ComplaintStatus = (Boolean?)value;
            if (ComplaintStatus == null)
                return "";
            else if (ComplaintStatus == true)
                return "Yes";
            else if (ComplaintStatus == false)
                return "No";

            return String.Empty;
        }
    }
}
