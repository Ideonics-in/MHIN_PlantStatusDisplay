using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Labour
    {
        public int LabourID { get; set; }
        public float PrevDayPaidHours { get; set; }
        public float SAPStdHours { get; set; }
        public float MonthlyPaidHours { get; set; }
        public float SAPMonthlyStdHours { get; set; }
        public float Efficiency { get; set; }
    }
}
