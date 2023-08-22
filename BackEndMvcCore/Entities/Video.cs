using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
	public class Video:BaseModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Link { get; set; }
	}
}
