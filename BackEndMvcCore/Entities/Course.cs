using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class Course:BaseModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string About { get; set; }   
        public string Apply { get; set; }
        public string Certification { get; set; }
        public string Duration { get; set; }
        public string ClassDuration { get; set; }
        public string SkillLevel { get; set; }
        public int StudentCount { get; set; }   
        public double Price { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }
        public List<CourseTag> Coursetags { get; set; }
        [NotMapped]
        public List<int> TagIds { get; set; }
    }
}
