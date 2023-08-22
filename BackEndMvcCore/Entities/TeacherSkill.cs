using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class TeacherSkill:BaseModel
    {
        public int TeacherId { get; set; }
        public int SkillId { get; set; }    
        public Teacher teacher { get; set; }
        public Skill skill { get; set; }
    }
}
