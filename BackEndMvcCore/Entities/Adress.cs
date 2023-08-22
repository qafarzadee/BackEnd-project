using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class Adress:BaseModel
    {
        public string Adresss { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
    }
}
