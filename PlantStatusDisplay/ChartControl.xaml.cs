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
    /// Interaction logic for ChartControl.xaml
    /// </summary>
    public partial class ChartControl : UserControl
    {
        LPATrend LPATrend;
        NQCTrend NQCTrend;
        OEETrend OEETrend;
        InventoryTrend InventoryTrend;
        public ChartControl()
        {

            InitializeComponent();

            LPATrend = new LPATrend();

            NQCTrend = new NQCTrend();
            OEETrend = new OEETrend();
            InventoryTrend = new InventoryTrend();
            
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
        public List<KeyValuePair<String, double>> LPATarget { get; set; }
        public List<KeyValuePair<String, double>> LPAActual { get; set; }

        public LPATrend()
        {
            LPAActual = new List<KeyValuePair<string, double>>();
            LPAActual.Add(new KeyValuePair<string, double>("Jan", 78));
            LPAActual.Add(new KeyValuePair<string, double>("Feb", 79));
            LPAActual.Add(new KeyValuePair<string, double>("Mar", 80));
            LPAActual.Add(new KeyValuePair<string, double>("Apr", 75));
            LPAActual.Add(new KeyValuePair<string, double>("May", 74));
            LPAActual.Add(new KeyValuePair<string, double>("Jun", 73));
            LPAActual.Add(new KeyValuePair<string, double>("Jul", 68));
            LPAActual.Add(new KeyValuePair<string, double>("Aug", 78));
            LPAActual.Add(new KeyValuePair<string, double>("Sep", 77));
            LPAActual.Add(new KeyValuePair<string, double>("Oct", 75));
            LPAActual.Add(new KeyValuePair<string, double>("Nov", 74));
            LPAActual.Add(new KeyValuePair<string, double>("Dec", 79));

            LPATarget = new List<KeyValuePair<string, double>>();
            LPATarget.Add(new KeyValuePair<string, double>("Jan", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Feb", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Mar", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Apr", 80));
            LPATarget.Add(new KeyValuePair<string, double>("May", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Jun", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Jul", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Aug", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Sep", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Oct", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Nov", 80));
            LPATarget.Add(new KeyValuePair<string, double>("Dec", 80));
        }
    }


    public class NQCTrend
    {
        public List<String> Months { get; set; }
        public List<KeyValuePair<String, double>> Target { get; set; }
        public List<KeyValuePair<String, double>> Actual { get; set; }

        public NQCTrend()
        {
            Actual = new List<KeyValuePair<string, double>>();
            Actual.Add(new KeyValuePair<string, double>("Jan", .28));
            Actual.Add(new KeyValuePair<string, double>("Feb", .25));
            Actual.Add(new KeyValuePair<string, double>("Mar", .27));
            Actual.Add(new KeyValuePair<string, double>("Apr", .28));
            Actual.Add(new KeyValuePair<string, double>("May", .28));
            Actual.Add(new KeyValuePair<string, double>("Jun", .26));
            Actual.Add(new KeyValuePair<string, double>("Jul", .27));
            Actual.Add(new KeyValuePair<string, double>("Aug", .28));
            Actual.Add(new KeyValuePair<string, double>("Sep", .29));
            Actual.Add(new KeyValuePair<string, double>("Oct", .29));
            Actual.Add(new KeyValuePair<string, double>("Nov", .24));
            Actual.Add(new KeyValuePair<string, double>("Dec", .29));

            Target = new List<KeyValuePair<string, double>>();
            Target.Add(new KeyValuePair<string, double>("Jan", .29));
            Target.Add(new KeyValuePair<string, double>("Feb", .29));
            Target.Add(new KeyValuePair<string, double>("Mar", .29));
            Target.Add(new KeyValuePair<string, double>("Apr", .29));
            Target.Add(new KeyValuePair<string, double>("May", .29));
            Target.Add(new KeyValuePair<string, double>("Jun", .29));
            Target.Add(new KeyValuePair<string, double>("Jul", .29));
            Target.Add(new KeyValuePair<string, double>("Aug", .29));
            Target.Add(new KeyValuePair<string, double>("Sep", .29));
            Target.Add(new KeyValuePair<string, double>("Oct", .29));
            Target.Add(new KeyValuePair<string, double>("Nov", .29));
            Target.Add(new KeyValuePair<string, double>("Dec", .29));
        }
    }


    public class OEETrend
    {
        public List<String> Months { get; set; }
        public List<KeyValuePair<String, double>> Target { get; set; }
        public List<KeyValuePair<String, double>> Actual { get; set; }

        public OEETrend()
        {
            Actual = new List<KeyValuePair<string, double>>();
            Actual.Add(new KeyValuePair<string, double>("Jan", 80.8));
            Actual.Add(new KeyValuePair<string, double>("Feb", 81.5));
            Actual.Add(new KeyValuePair<string, double>("Mar", 77.3));
            Actual.Add(new KeyValuePair<string, double>("Apr", 81.5));
            Actual.Add(new KeyValuePair<string, double>("May", 81.6));
            Actual.Add(new KeyValuePair<string, double>("Jun", 80.5));
            Actual.Add(new KeyValuePair<string, double>("Jul", 80.6));
            Actual.Add(new KeyValuePair<string, double>("Aug", 82));
            Actual.Add(new KeyValuePair<string, double>("Sep", 79.9));
            Actual.Add(new KeyValuePair<string, double>("Oct", 78.5));
            Actual.Add(new KeyValuePair<string, double>("Nov", 81.5));
            Actual.Add(new KeyValuePair<string, double>("Dec", 80.7));

            Target = new List<KeyValuePair<string, double>>();
            Target.Add(new KeyValuePair<string, double>("Jan", 83.4));
            Target.Add(new KeyValuePair<string, double>("Feb", 83.4));
            Target.Add(new KeyValuePair<string, double>("Mar", 83.4));
            Target.Add(new KeyValuePair<string, double>("Apr", 83.4));
            Target.Add(new KeyValuePair<string, double>("May", 83.4));
            Target.Add(new KeyValuePair<string, double>("Jun", 83.4));
            Target.Add(new KeyValuePair<string, double>("Jul", 83.4));
            Target.Add(new KeyValuePair<string, double>("Aug", 83.4));
            Target.Add(new KeyValuePair<string, double>("Sep", 83.4));
            Target.Add(new KeyValuePair<string, double>("Oct", 83.4));
            Target.Add(new KeyValuePair<string, double>("Nov", 83.4));
            Target.Add(new KeyValuePair<string, double>("Dec", 83.4));
        }
    }

    public class InventoryTrend
    {
        public List<KeyValuePair<String, double>> Average { get; set; }
        public List<KeyValuePair<String, double>> Target { get; set; }
        public List<KeyValuePair<String, double>> Actual { get; set; }

        public InventoryTrend()
        {
            Actual = new List<KeyValuePair<string, double>>();
            Actual.Add(new KeyValuePair<string, double>("Jan", 44));
            Actual.Add(new KeyValuePair<string, double>("Feb", 42.2));
            Actual.Add(new KeyValuePair<string, double>("Mar", 47.6));
            Actual.Add(new KeyValuePair<string, double>("Apr", 44.7));
            Actual.Add(new KeyValuePair<string, double>("May", 45));
            Actual.Add(new KeyValuePair<string, double>("Jun", 46));
            Actual.Add(new KeyValuePair<string, double>("Jul", 45));
            Actual.Add(new KeyValuePair<string, double>("Aug", 44.5));
            Actual.Add(new KeyValuePair<string, double>("Sep", 45.8));
            Actual.Add(new KeyValuePair<string, double>("Oct", 42));
            Actual.Add(new KeyValuePair<string, double>("Nov", 43.3));
            Actual.Add(new KeyValuePair<string, double>("Dec", 43.6));

            Target = new List<KeyValuePair<string, double>>();
            Target.Add(new KeyValuePair<string, double>("Jan", 40));
            Target.Add(new KeyValuePair<string, double>("Feb", 40));
            Target.Add(new KeyValuePair<string, double>("Mar", 40));
            Target.Add(new KeyValuePair<string, double>("Apr", 40));
            Target.Add(new KeyValuePair<string, double>("May", 40));
            Target.Add(new KeyValuePair<string, double>("Jun", 40));
            Target.Add(new KeyValuePair<string, double>("Jul", 40));
            Target.Add(new KeyValuePair<string, double>("Aug", 40));
            Target.Add(new KeyValuePair<string, double>("Sep", 40));
            Target.Add(new KeyValuePair<string, double>("Oct", 40));
            Target.Add(new KeyValuePair<string, double>("Nov", 40));
            Target.Add(new KeyValuePair<string, double>("Dec", 40));

            Average = new List<KeyValuePair<string, double>>();
            Average.Add(new KeyValuePair<string, double>("Jan", 53.3));
            Average.Add(new KeyValuePair<string, double>("Feb", 51.9));
            Average.Add(new KeyValuePair<string, double>("Mar", 51.4));
            Average.Add(new KeyValuePair<string, double>("Apr", 51.1));
            Average.Add(new KeyValuePair<string, double>("May", 50.8));
            Average.Add(new KeyValuePair<string, double>("Jun", 49.9));
            Average.Add(new KeyValuePair<string, double>("Jul", 45.2));
            Average.Add(new KeyValuePair<string, double>("Aug", 44.8));
            Average.Add(new KeyValuePair<string, double>("Sep", 44.5));
            Average.Add(new KeyValuePair<string, double>("Oct", 43.9));
            Average.Add(new KeyValuePair<string, double>("Nov", 43.5));
            Average.Add(new KeyValuePair<string, double>("Dec", 43.2));
        }
    }
}
