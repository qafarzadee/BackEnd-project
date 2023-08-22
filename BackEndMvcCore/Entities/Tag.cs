using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class Tag:BaseModel
    {
        [Required]
        public string Name { get; set; }
        public List<CourseTag> Coursetags { get; set; }
        public List<EventTag> EventTags { get; set; }
        public List<BlogTag> blogTags { get; set; }

    }
}
