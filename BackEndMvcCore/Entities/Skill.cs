using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMvcCore.Entities
{
    public class Skill:BaseModel
    {
        public int Percent { get; set; }
        public string Name { get; set; }
        public List<TeacherSkill> TeacherSkills { get; set; }
    }
}
