using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public BlogController(BackEndProjectDbContext context, IWebHostEnvironment enviroment)
        {
            _context= context;
            _environment=enviroment;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _context.blogs
                .Where(x => !x.IsDeleted)
                 .Include(x=>x.blogTags.Where(x=>!x.IsDeleted))
                  .ToListAsync();
            return View(blogs);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Tags = await _context.tags.Where(x => !x.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            blog.Image = blog.formFile.CreateImage(_environment.WebRootPath, "Assets/img");
            foreach (var item in blog.TagIds)
            {
                BlogTag blogTag = new BlogTag()
                {
                    TagId=item,
                    blog=blog
                };
                await _context.blogTags.AddAsync(blogTag);
            }
            await _context.blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
