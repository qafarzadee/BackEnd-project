using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public CourseController(BackEndProjectDbContext context)
        {
            _context= context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _context.courses
                .Where(x => !x.IsDeleted)
                 .ToListAsync();
            return View(courses);
        }

       public async Task<IActionResult> Detail(int id)
        {
            Course? course = await _context.courses
                .Where(x => !x.IsDeleted && x.Id == id)
                 .Include(x => x.Coursetags.Where(x => !x.IsDeleted))
                  .ThenInclude(x => x.tag)
                    .FirstOrDefaultAsync();

            ViewBag.ExtraEvents = await _context.Events
           .Where(x => !x.IsDeleted && x.Id != id)
            .Take(3)
             .ToListAsync();

            return View(course);
        }
    }
}
