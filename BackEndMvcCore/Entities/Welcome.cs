using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class Welcome:BaseModel
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Formfile { get; set; }
    }
}
