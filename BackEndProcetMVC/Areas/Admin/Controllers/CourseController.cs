using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public CourseController(BackEndProjectDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _context.courses
                .Where(x => !x.IsDeleted)
                  .Include(x => x.Coursetags.Where(a => !a.IsDeleted))
                  .ToListAsync();
            return View(courses);
        }
        [HttpGet]

        public async Task<IActionResult> Create()
        {
            ViewBag.Tags = await _context.tags
                .Where(x => !x.IsDeleted)
                 .ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            course.Image = course.formFile.CreateImage(_enviroment.WebRootPath,"Assets/img");
            course.CreatedDate=DateTime.Now;
            foreach (var item in course.TagIds)
            {
                CourseTag CourseTag = new CourseTag()
                {
                    course=course,
                    TagId=item,
                    CreatedDate=DateTime.Now
                };
                await _context.courseTags.AddAsync(CourseTag);
            }
            await _context.courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Course? course = await _context.courses
                .FindAsync(id);
            if (course == null)
                return NotFound();
            course.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}
