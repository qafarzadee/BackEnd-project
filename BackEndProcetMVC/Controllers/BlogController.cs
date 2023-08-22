using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public BlogController(BackEndProjectDbContext context)
        {
            _context=context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs=await _context.blogs.Where(x=>!x.IsDeleted).ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Blog? blog = await _context.blogs
                .Where(x => !x.IsDeleted && x.Id == id)
                 .FirstOrDefaultAsync();

            ViewBag.ExtraBlogs = await _context.blogs.Where(x => !x.IsDeleted && x.Id != id).ToListAsync();
            return View(blog);
        }

    }
}
