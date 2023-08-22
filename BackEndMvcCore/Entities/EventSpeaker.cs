using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class EventSpeaker:BaseModel
    {
        public int EventId { get; set; }
        public int SpekaerId { get; set; }
        public Speaker speaker { get; set; }
        public Event eventt { get; set; }
    }
}
