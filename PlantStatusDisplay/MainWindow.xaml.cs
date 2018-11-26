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

            using (var db = new PSDB())
            {
                var stats = from s in db.MonthlyStats
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

            CustomerComplaints = new ObservableCollection<CustomerComplaint>();

            CustomerComplaints.Add(new CustomerComplaint { Logo = "./Images/Ford.png",
                JanStatus = "Yes", FebStatus="No",MarStatus="No",AprStatus="No",MayStatus = "Yes",JunStatus = "No",
            JulStatus="Yes", AugStatus="No", SepStatus="No", OctStatus="No", NovStatus="No",DecStatus="" });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/Mahindra.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/AshokLeyland.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/aisin.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/Fiat.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/tata.png",
                JanStatus = "No",
                FebStatus = "Yes",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/BharatBenz.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/Volvo.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/atlas.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/elgi.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/tafe.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/ir.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });
            CustomerComplaints.Add(new CustomerComplaint
            {
                Logo = "./Images/doosan.png",
                JanStatus = "No",
                FebStatus = "No",
                MarStatus = "No",
                AprStatus = "No",
                MayStatus = "No",
                JunStatus = "No",
                JulStatus = "No",
                AugStatus = "No",
                SepStatus = "No",
                OctStatus = "No",
                NovStatus = "No",
                DecStatus = ""
            });

            CustomerComplaintStatus.StatusGrid.DataContext = CustomerComplaints;




           // Slides.Enqueue(AccidentDurationDisplay);
          //  Slides.Enqueue(CustomerComplaintDuration);
           // Slides.Enqueue(ChartControl);
            Slides.Enqueue(CustomerComplaintStatus);
            

            BaseGrid.Children.Add(AndonStatus);

           
            
        }

        

        private void SlideChange_Elapsed(object sender, ElapsedEventArgs e)
        {
            UserControl uc = Slides.Dequeue();
            BaseGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
            {
            
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
