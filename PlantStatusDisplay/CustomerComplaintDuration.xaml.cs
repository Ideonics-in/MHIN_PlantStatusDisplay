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
        DateTime? _lastCustomerComplaint;
        public CustomerComplaintDuration(DateTime? lastCustomerComplaint)
        {
            InitializeComponent();

            _lastCustomerComplaint = lastCustomerComplaint;
            DayTextBlock_1.Text = lastCustomerComplaint.Value.Day.ToString("D2").Substring(0, 1);
            DayTextBlock_2.Text = lastCustomerComplaint.Value.Day.ToString("D2").Substring(1, 1);

            MonthTextBlock_1.Text = lastCustomerComplaint.Value.Month.ToString("D2").Substring(0, 1);
            MonthTextBlock_2.Text = lastCustomerComplaint.Value.Month.ToString("D2").Substring(1, 1);

            YearTextBlock_1.Text = lastCustomerComplaint.Value.Year.ToString().Substring(0, 1);
            YearTextBlock_2.Text = lastCustomerComplaint.Value.Year.ToString().Substring(1, 1);
            YearTextBlock_3.Text = lastCustomerComplaint.Value.Year.ToString().Substring(2, 1);
            YearTextBlock_4.Text = lastCustomerComplaint.Value.Year.ToString().Substring(3, 1);


            TodayTextBlock_1.Text = DateTime.Now.Day.ToString("D2").Substring(0, 1);
            TodayTextBlock_2.Text = DateTime.Now.Day.ToString("D2").Substring(1, 1);

            CurMonthTextBlock_1.Text = DateTime.Now.Month.ToString("D2").Substring(0, 1);
            CurMonthTextBlock_2.Text = DateTime.Now.Month.ToString("D2").Substring(1, 1);

            CurYearTextBlock_1.Text = DateTime.Now.Year.ToString().Substring(0, 1);
            CurYearTextBlock_2.Text = DateTime.Now.Year.ToString().Substring(1, 1);
            CurYearTextBlock_3.Text = DateTime.Now.Year.ToString().Substring(2, 1);
            CurYearTextBlock_4.Text = DateTime.Now.Year.ToString().Substring(3, 1);



            DurationTextBlock_1.Text = (DateTime.Now - lastCustomerComplaint.Value).Days.ToString("D3").Substring(0, 1);
            DurationTextBlock_2.Text = (DateTime.Now - lastCustomerComplaint.Value).Days.ToString("D3").Substring(1, 1);
            DurationTextBlock_3.Text = (DateTime.Now - lastCustomerComplaint.Value).Days.ToString("D3").Substring(2, 1);
            





        }

        public void Update()
        {
            TodayTextBlock_1.Text = DateTime.Now.Day.ToString("D2").Substring(0, 1);
            TodayTextBlock_2.Text = DateTime.Now.Day.ToString("D2").Substring(1, 1);

            CurMonthTextBlock_1.Text = DateTime.Now.Month.ToString("D2").Substring(0, 1);
            CurMonthTextBlock_2.Text = DateTime.Now.Month.ToString("D2").Substring(1, 1);

            CurYearTextBlock_1.Text = DateTime.Now.Year.ToString().Substring(0, 1);
            CurYearTextBlock_2.Text = DateTime.Now.Year.ToString().Substring(1, 1);
            CurYearTextBlock_3.Text = DateTime.Now.Year.ToString().Substring(2, 1);
            CurYearTextBlock_4.Text = DateTime.Now.Year.ToString().Substring(3, 1);



            DurationTextBlock_1.Text = (DateTime.Now - _lastCustomerComplaint.Value).Days.ToString("D3").Substring(0, 1);
            DurationTextBlock_2.Text = (DateTime.Now - _lastCustomerComplaint.Value).Days.ToString("D3").Substring(1, 1);
            DurationTextBlock_3.Text = (DateTime.Now - _lastCustomerComplaint.Value).Days.ToString("D3").Substring(2, 1);

        }
    }
}
