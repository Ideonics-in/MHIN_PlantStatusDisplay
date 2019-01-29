using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        Dictionary<String, Event> EventDictionary;
        public MainWindow()
        {
            InitializeComponent();

            MonthlyStats = new ObservableCollection<MonthlyStat>();
            
            EventDictionary = new Dictionary<string, Event>();

            using (var db = new PSDB())
            {
                var stats = from s in db.MonthlyStats
                            select s;
                var events = from e in db.Events
                             select e;

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

                StatsDataGrid.DataContext = MonthlyStats;
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
    }
}
