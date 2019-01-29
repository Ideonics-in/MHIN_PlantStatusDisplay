using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public float InventoryValue { get; set; }
        public float CurrentCOGS { get; set; }
        public float ClosingInventory { get; set; }
        public float MonthlyCOGS { get; set; }
        public int DailyInventory { get; set; }
    }
}
