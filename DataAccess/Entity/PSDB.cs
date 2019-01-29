using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class PSDB : DbContext
    {
        public PSDB() : base("name=PSDBConnectionString")
        {
            
        }

        public DbSet<MonthlyStat> MonthlyStats { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

    }

   



}
