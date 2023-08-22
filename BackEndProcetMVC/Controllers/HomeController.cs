using BackEndProcetMVC.Context;
using BackEndProcetMVC.Models;
using BackEndProcetMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BackEndProcetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public HomeController(BackEndProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel modelHome = new HomeViewModel()
            {
                sliders = await _context.sliders
                .Where(x => !x.IsDeleted)
                 .ToListAsync(),

                welcomes = await _context.welcomes
                .Where(a => !a.IsDeleted)
                  .ToListAsync(),

                videos = await _context.videos
                 .Where(x => x.Id == 1)
                  .ToListAsync(),

                noticeboards = await _context.NoticeBoards
                .Where(x => !x.IsDeleted)
                  .ToListAsync(),

                courses = await _context.courses
                .Where(x => !x.IsDeleted)
                .Include(a => a.Coursetags)
                .ThenInclude(x => x.tag)
                 .Take(3)
                 .ToListAsync(),

                extraInfos = await _context.ExtraInfos
                .Where(x => !x.IsDeleted)
                .ToListAsync(),

                events = await _context.Events
                .Where(x => !x.IsDeleted)
                 .Include(a => a.speakers.Where(x => !x.IsDeleted))
                 .Include(x => x.EventTags)
                  .ThenInclude(a => a.Tag)
                   .ToListAsync(),

                blogs = await _context.blogs
                .Where(a => !a.IsDeleted)
                 .Include(a => a.blogTags)
                  .ToListAsync(),

                pageInfos=await _context.pageInfoos.Where(x=>!x.IsDeleted).ToListAsync()
            };
            return View(modelHome);
        }

   
    }
}