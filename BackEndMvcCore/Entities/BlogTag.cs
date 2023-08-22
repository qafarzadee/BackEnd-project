using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class BlogTag:BaseModel
    {
        public int TagId { get; set; }
        public int BlogId { get; set; }
        public Tag tag { get; set; }
        public Blog blog { get; set; }
    }
}
