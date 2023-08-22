using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class NoticeBoard:BaseModel
    {
        [Required]
        public string Description { get; set; }
    }
}
