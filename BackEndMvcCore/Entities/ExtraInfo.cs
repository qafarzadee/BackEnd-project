using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class ExtraInfo:BaseModel
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
