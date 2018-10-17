using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class DB : DbContext
    {
        public DB()
        {

        }

        public DbSet<MonthlyStat> MonthlyStats { get; set; }
    }

   



}
