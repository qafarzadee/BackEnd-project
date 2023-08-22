using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
   public class CourseTag:BaseModel
    {
        public int CourseId { get; set; }
        public int TagId { get; set; }
        public Course course { get; set; }
        public Tag tag { get; set; }    
    }
}
