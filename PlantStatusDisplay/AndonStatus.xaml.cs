using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Interaction logic for AndonStatus.xaml
    /// </summary>
    public partial class AndonStatus : UserControl
    {
        Timer StatusUpdateTimer;
        Dictionary<String, Border> LineStatusDictionary;

        ObservableCollection<Line> Lines;
        public AndonStatus()
        {

            this.InheritanceBehavior = InheritanceBehavior.SkipAllNow;

            InitializeComponent();

            Lines = new ObservableCollection<Line>();
            
            DataTable linesTable= GetLines();
            for(int i = 0; i < linesTable.Rows.Count; i++)
            {
                Lines.Add(new Line { ID = (int)linesTable.Rows[i]["id"],
                    Name = (string)linesTable.Rows[i]["description"],
                    Status = "No Plan" });

            }

            foreach (Line l in Lines)
            {
                string tag = "Line_" + l.ID;
                if (this.FindName(tag) != null)
                {
                    
                        LineStatusWidget w = (LineStatusWidget)this.FindName(tag);
                        w.DataContext = l;
                    
                    //else
                    //{
                    //    Border b = (Border)this.FindName(tag);
                    //    b.DataContext = l;
                    //}
                    
                }
            
            }
            
 
        





            StatusUpdateTimer = new Timer(5000);
            StatusUpdateTimer.AutoReset = false;
            StatusUpdateTimer.Elapsed += StatusUpdateTimer_Elapsed;

           

           
            StatusUpdateTimer.Start();

    
        }

        private void StatusUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StatusUpdateTimer.Stop();

            DataTable lines = GetLines();

            UpdateDisplay(lines);
            ClockTextBlock.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background,
                new Action(() =>
                {
                    ClockTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy\n    HH:mm");
                }));
            StatusUpdateTimer.Start();
        }

        private void UpdateDisplay(DataTable lineTable)
        {
            SolidColorBrush backgroundBrush = Brushes.White ;
            for (int i = 0; i < lineTable.Rows.Count; i++)
            {
                foreach(Line l in  Lines)
                {
                    if(l.ID == (int) lineTable.Rows[i]["id"])
                    {
                        l.Status = (string)lineTable.Rows[i]["Status"];
                    }
                }
            }


        }

        DataTable GetLines()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;database=MHIN_ANDON_DB;User id=sa; Password=ide123$%^;");
            con.Open();



            String qry = String.Empty;
            qry = @"SELECT id, description, Status  FROM lines ORDER BY id";

            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cmd.Dispose();



            con.Close();
            con.Dispose();
            return dt;
        }
    }


    [ValueConversion(typeof(string), typeof(Brush))]
    public class StringToStatusCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush solidColorBrush = Brushes.White;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                if (value.ToString() == "Running")
                {
                    solidColorBrush = Brushes.Lime;
                }
                else if((value.ToString() == "Acknowledged"))
                {
                    solidColorBrush = Brushes.Yellow;

                }

                else if ((value.ToString() == "Down"))
                {
                    solidColorBrush = Brushes.Red;

                }
            }

            return solidColorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Line : INotifyPropertyChanged
    {
        public int ID { get; set; }
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        

        string status = String.Empty;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        #region INotifyPropetyChangedHandler
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
