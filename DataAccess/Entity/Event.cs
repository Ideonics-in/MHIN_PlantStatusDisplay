using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Event
    {
            
        public int ID { get; set; }
        public String Tag { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
