using System;
using System.Collections.Generic;
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

namespace PlantStatusDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccidentDurationDisplay AccidentDurationDisplay;
        CustomerComplaintDuration CustomerComplaintDuration;
        ChartControl ChartControl;
        Queue<UserControl> Slides;

        Timer SlideChange;

        public MainWindow()
        {
            InitializeComponent();

            Slides = new Queue<UserControl>();

            SlideChange = new Timer(5000);
            SlideChange.AutoReset = true;
            SlideChange.Elapsed += SlideChange_Elapsed;
            AccidentDurationDisplay = new AccidentDurationDisplay(new DateTime(2018,1,1,0,0,0));
            CustomerComplaintDuration = new CustomerComplaintDuration(new DateTime(2018, 2, 1, 0, 0, 0));
            ChartControl = new ChartControl();

            
            //Slides.Enqueue(CustomerComplaintDuration);
            Slides.Enqueue(ChartControl);
            //Slides.Enqueue(AccidentDurationDisplay);

            BaseGrid.Children.Add(AccidentDurationDisplay);
            SlideChange.Start();
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
    }
}
