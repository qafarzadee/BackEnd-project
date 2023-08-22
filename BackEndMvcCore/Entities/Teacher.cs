using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class Teacher:BaseModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public int ExperienceYear { get; set; }
        public string Phone { get; set; } 
        public string FaceBookLink { get; set; }
        public string InstagramLink { get; set; }
        public string LinkedinLink { get; set; }
        public int LanguagePercent { get; set; }
        public int TeamLeaderPercent { get; set; }
        public int DevelopmentPercent { get; set; }
        public int DesignPercent { get; set; }
        public int InnovationPercent { get; set; }
        public int CommunicationPercent { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }   
        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
