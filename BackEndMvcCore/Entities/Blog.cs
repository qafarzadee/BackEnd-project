using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class Blog:BaseModel
    {
        public string Owner { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<BlogTag> blogTags { get; set; }
        [NotMapped]
        public List<int> TagIds { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
