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

namespace PlantStatusDisplay
{
    /// <summary>
    /// Interaction logic for ChartControl.xaml
    /// </summary>
    public partial class ChartControl : UserControl
    {
        LPATrend LPATrend;
        NQCTrend NQCTrend;
        OEETrend OEETrend;
        InventoryTrend InventoryTrend;
        public ChartControl(ObservableCollection<MonthlyStat> Stats)
        {

            InitializeComponent();

            LPATrend = new LPATrend(Stats);

            NQCTrend = new NQCTrend(Stats);
            OEETrend = new OEETrend(Stats);
            InventoryTrend = new InventoryTrend(Stats);
            
            LPAActualTrend.DataContext = LPATrend.LPAActual;
            LPATargetTrend.DataContext = LPATrend.LPATarget;

            NQCActualTrend.DataContext = NQCTrend.Actual;
            NQCTargetTrend.DataContext = NQCTrend.Target;

            OEEActualTrend.DataContext = OEETrend.Actual;
            OEETargetTrend.DataContext = OEETrend.Target;

            InventoryActualTrend.DataContext = InventoryTrend.Actual;
            InventoryTargetTrend.DataContext = InventoryTrend.Target;
            InventoryAvgTrend.DataContext = InventoryTrend.Average;
        }


    }
    public class LPATrend
    {
        public List<String> Months { get; set; }
        public List<KeyValuePair<String, float?>> LPATarget { get; set; }
        public List<KeyValuePair<String, float?>> LPAActual { get; set; }

        public LPATrend(ObservableCollection<MonthlyStat> Stats)
        {
            Months = new List<string>();
            Months.Add("Avg");
            Months.Add("Jan"); Months.Add("Feb"); Months.Add("Mar"); Months.Add("Apr");
            Months.Add("May"); Months.Add("Jun"); Months.Add("Jul"); Months.Add("Aug");
            Months.Add("Sep"); Months.Add("Oct"); Months.Add("Nov"); Months.Add("Dec");
            

            LPAActual = new List<KeyValuePair<string, float?>>();
            LPATarget = new List<KeyValuePair<string, float?>>();
            int i = 0;
            foreach(MonthlyStat s in Stats)
            {

                
                    LPAActual.Add(new KeyValuePair<string, float?>(s.Month, s.LPC_Actual));
                    LPATarget.Add(new KeyValuePair<string, float?>(s.Month, s.LPC_Target));
                
               

                
            }

            
            
           
        }
    }


    public class NQCTrend
    {
        public List<String> Months { get; set; }
        public List<KeyValuePair<String, float?>> Target { get; set; }
        public List<KeyValuePair<String, float?>> Actual { get; set; }

        public NQCTrend(ObservableCollection<MonthlyStat> Stats)
        {
            Months = new List<string>();
            Months.Add("Avg");
            Months.Add("Jan"); Months.Add("Feb"); Months.Add("Mar"); Months.Add("Apr");
            Months.Add("May"); Months.Add("Jun"); Months.Add("Jul"); Months.Add("Aug");
            Months.Add("Sep"); Months.Add("Oct"); Months.Add("Nov"); Months.Add("Dec");
            int i = 0;


            Actual = new List<KeyValuePair<string, float?>>();
            Target = new List<KeyValuePair<string, float?>>();


            foreach (MonthlyStat s in Stats)
            {
            
                    Actual.Add(new KeyValuePair<string, float?>(s.Month, s.NQC_Actual));
                    Target.Add(new KeyValuePair<string, float?>(s.Month, s.NQC_Target));
                    Months.RemoveAt(i);
                    
            }
            
        }
    }


    public class OEETrend
    {
        public List<String> Months { get; set; }
        public List<KeyValuePair<String, float?>> Target { get; set; }
        public List<KeyValuePair<String, float?>> Actual { get; set; }

        public OEETrend(ObservableCollection<MonthlyStat> Stats)
        {
            Months = new List<string>();
            Months.Add("Avg");
            Months.Add("Jan"); Months.Add("Feb"); Months.Add("Mar"); Months.Add("Apr");
            Months.Add("May"); Months.Add("Jun"); Months.Add("Jul"); Months.Add("Aug");
            Months.Add("Sep"); Months.Add("Oct"); Months.Add("Nov"); Months.Add("Dec");
            int i = 0;

            Actual = new List<KeyValuePair<string, float?>>();
            Target = new List<KeyValuePair<string, float?>>();
            foreach (MonthlyStat s in Stats)
            {
               
                    Actual.Add(new KeyValuePair<string, float?>(s.Month, s.OEE_Actual));
                    Target.Add(new KeyValuePair<string, float?>(s.Month, s.OEE_Target));
                    Months.RemoveAt(i);
               
            }

            
        }
    }

    public class InventoryTrend
    {
        public List<String> Months { get; set; }
        public List<KeyValuePair<String, float?>> Average { get; set; }
        public List<KeyValuePair<String, float?>> Target { get; set; }
        public List<KeyValuePair<String, float?>> Actual { get; set; }

        public InventoryTrend(ObservableCollection<MonthlyStat> Stats)
        {
            Months = new List<string>();
            Months.Add("Avg");
            Months.Add("Jan"); Months.Add("Feb"); Months.Add("Mar"); Months.Add("Apr");
            Months.Add("May"); Months.Add("Jun"); Months.Add("Jul"); Months.Add("Aug");
            Months.Add("Sep"); Months.Add("Oct"); Months.Add("Nov"); Months.Add("Dec");
            int i = 0;

            Actual = new List<KeyValuePair<string, float?>>();
            Target = new List<KeyValuePair<string, float?>>();
            Average = new List<KeyValuePair<string, float?>>();


            foreach (MonthlyStat s in Stats)
            {
               
                    Average.Add(new KeyValuePair<string, float?>(s.Month, s.Inventory_Average));
                    Actual.Add(new KeyValuePair<string, float?>(s.Month, s.Inventory_Actual));
                    Target.Add(new KeyValuePair<string, float?>(s.Month, s.Inventory_Target));
              
            }
            
        }
    }
}
