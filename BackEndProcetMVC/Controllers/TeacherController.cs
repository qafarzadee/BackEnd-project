using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public TeacherController(BackEndProjectDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<Teacher> teachers = await _context.Teachers.Where(a => !a.IsDeleted).ToListAsync();
            return View(teachers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Teacher? teacher = await _context.Teachers
                 .Where(x => !x.IsDeleted && x.Id == id)
                  .FirstOrDefaultAsync();
            return View(teacher);
        }
    }
}
