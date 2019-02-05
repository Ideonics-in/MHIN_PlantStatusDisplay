using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Entity;

namespace PlantStatusDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccidentDurationDisplay AccidentDurationDisplay;
        CustomerComplaintDuration CustomerComplaintDuration;
        CustomerComplaintStatus CustomerComplaintStatus;
        AndonStatus AndonStatus;
        ChartControl ChartControl;
        Queue<UserControl> Slides;

        ObservableCollection<CustomerComplaint> CustomerComplaints;

        ObservableCollection<MonthlyStat> MonthlyStats;

        Dictionary<String, Event> EventDictionary;
      
        Timer SlideChange;

        bool SlideMode = false;

        public MainWindow()
        {
            InitializeComponent();
            MonthlyStats = new ObservableCollection<MonthlyStat>();
            EventDictionary = new Dictionary<string, Event>();
            CustomerComplaints = new ObservableCollection<CustomerComplaint>();

            using (var db = new PSDB())
            {
                var avgStats = db.MonthlyStats.Where(s => s.Year == DateTime.Now.Year - 1).ToList();

                var avgStat = new MonthlyStat();
                foreach(MonthlyStat s in avgStats)
                {
                    avgStat.Inventory_Actual += ((s.Inventory_Actual) == null ? 0 : s.Inventory_Actual);
                    avgStat.Inventory_Average += ((s.Inventory_Average) == null ? 0 : s.Inventory_Average);
                    avgStat.Inventory_Target += ((s.Inventory_Target) == null ? 0 : s.Inventory_Target);
                    avgStat.LPC_Actual += ((s.LPC_Actual) == null ? 0 : s.LPC_Actual);
                    avgStat.LPC_Target += ((s.LPC_Target) == null ? 0 : s.LPC_Target);
                    avgStat.NQC_Actual += ((s.NQC_Actual) == null ? 0 : s.NQC_Actual);
                    avgStat.NQC_Target += ((s.NQC_Target) == null ? 0 : s.NQC_Target);
                    avgStat.OEE_Actual += ((s.OEE_Actual) == null ? 0 : s.OEE_Actual);
                    avgStat.OEE_Target += ((s.OEE_Target) == null ? 0 : s.OEE_Target);

                }
                avgStat.Inventory_Actual /= avgStats.Count;
                avgStat.Inventory_Average /= avgStats.Count;
                avgStat.Inventory_Target /= avgStats.Count;
                avgStat.LPC_Actual /= avgStats.Count;
                avgStat.LPC_Target /= avgStats.Count;
                avgStat.NQC_Actual /= avgStats.Count;
                avgStat.NQC_Target /= avgStats.Count;
                avgStat.OEE_Actual /= avgStats.Count;
                avgStat.OEE_Target /= avgStats.Count;

                avgStat.Month = (DateTime.Now.Year-1).ToString() + "-Avg";

                MonthlyStats.Add(avgStat);

                var stats = from s in db.MonthlyStats
                            where s.Year == DateTime.Now.Year
                            select s;
                var events = from e in db.Events
                             select e;
 
                foreach (MonthlyStat m in stats)
                {
                    MonthlyStats.Add(m);

                }
                

                foreach (Event e in events)
                {
                    EventDictionary.Add(e.Tag, e);

                }
                var complaints = db.CustomerComplaints.ToList();

                foreach (CustomerComplaint c in complaints)
                {
                    CustomerComplaints.Add(c);

                }
            }

                Slides = new Queue<UserControl>();

            SlideChange = new Timer(5000);
            SlideChange.AutoReset = true;
            SlideChange.Elapsed += SlideChange_Elapsed;

            AndonStatus = new AndonStatus();

            AccidentDurationDisplay = new AccidentDurationDisplay(EventDictionary["LastAccidentDate"].Timestamp);
            CustomerComplaintDuration = new CustomerComplaintDuration(EventDictionary["CustomerComplaintDate"].Timestamp);
            CustomerComplaintStatus = new CustomerComplaintStatus();
            ChartControl = new ChartControl(MonthlyStats);

            

            CustomerComplaintStatus.StatusGrid.DataContext = CustomerComplaints;




           Slides.Enqueue(AccidentDurationDisplay);
           Slides.Enqueue(CustomerComplaintDuration);
           Slides.Enqueue(ChartControl);
            Slides.Enqueue(CustomerComplaintStatus);
            

            BaseGrid.Children.Add(AndonStatus);

           
            
        }

        

        private void SlideChange_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            UserControl uc = Slides.Dequeue();
            BaseGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
            {
                CustomerComplaintDuration.Update();
                AccidentDurationDisplay.Update();

                BaseGrid.Children.Clear();
                BaseGrid.Children.Add(uc);
                Slides.Enqueue(uc);
            
            }));
                }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1:
                    if (SlideMode == false)
                    {
                        UserControl uc = Slides.Dequeue();
                        BaseGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                        {

                            BaseGrid.Children.Clear();
                            BaseGrid.Children.Add(uc);
                            Slides.Enqueue(uc);
                            SlideChange.Start();
                            SlideMode = true;
                        }));


                    }
                    else if (SlideMode == true)
                    {
                        BaseGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                        {
                            SlideChange.Stop();
                            BaseGrid.Children.Clear();
                            BaseGrid.Children.Add(AndonStatus);
                            Slides.Clear();
                            Slides.Enqueue(AccidentDurationDisplay);
                            Slides.Enqueue(CustomerComplaintDuration);
                            Slides.Enqueue(ChartControl);
                            SlideMode = false;
                        }));
                    }
                    break;

            }
        }
    }

   
}
