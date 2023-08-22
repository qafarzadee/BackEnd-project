using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
   public class Event:BaseModel
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Speaker> speakers { get; set; }
        [NotMapped]
        public List<int>? SpeakerIds { get; set; }
        
        public List<EventTag> EventTags { get; set; }

        [NotMapped]
        public List<int>? TagIds { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        public List<EventSpeaker> eventSpeakers { get; set; }
        
    }
}
