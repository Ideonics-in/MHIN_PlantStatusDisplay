using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class MonthlyStat
    {
        public int ID { get; set; }
        public String Month { get; set; }
        public int Year { get; set; }
        public float? Inventory_Average { get; set; }
        public float? Inventory_Target { get; set; }
        public float? Inventory_Actual { get; set; }

        public float? LPC_Target { get; set; }
        public float? LPC_Actual { get; set; }

        public float? NQC_Target { get; set; }
        public float? NQC_Actual { get; set; }

        public float? OEE_Target { get; set; }
        public float? OEE_Actual { get; set; }

        public String CustomerComplaintStatus { get; set; }

        public MonthlyStat()
        {
            Inventory_Actual = Inventory_Average = Inventory_Target = 0;
            LPC_Actual = LPC_Target = 0;
            NQC_Actual = NQC_Target = 0;
            OEE_Actual = OEE_Target = 0;

        }

    }

}
