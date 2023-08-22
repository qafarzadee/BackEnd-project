using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class EventTag:BaseModel
    {
        public int EventId { get; set; }
        public int TagId { get; set; }
        public Event Event { get; set; }
        public Tag Tag { get; set; }
    }
}
