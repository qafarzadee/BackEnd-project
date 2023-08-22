using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public AboutController(BackEndProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AboutWelcome> welcomes = await _context.AboutWelcomes
                .Where(a => !a.IsDeleted)
                 .ToListAsync();

            ViewBag.Teachers=await _context.Teachers
                .Where(a => !a.IsDeleted)
                 .Take(4)
                  .ToListAsync();

            ViewBag.ExtraInfos = await _context.ExtraInfos
                .Where(a => !a.IsDeleted)
                 .ToListAsync();

            ViewBag.Videos = await _context.videos.Where(a => !a.IsDeleted).ToListAsync();

            ViewBag.NoticeBoards = await _context.NoticeBoards
                .Where(a => !a.IsDeleted)
                 .ToListAsync();
            return View(welcomes);
        }
        
    }
}
