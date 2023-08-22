using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Controllers;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutWelcomeController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public AboutWelcomeController(BackEndProjectDbContext context, IWebHostEnvironment enviroment)
        {
            _context= context;
            _enviroment= enviroment;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<AboutWelcome> welcomes = await _context.AboutWelcomes
                .Where(x => !x.IsDeleted)
                  .ToListAsync();
            return View(welcomes);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AboutWelcome welcome)
        {
            welcome.Image = welcome.formFile.CreateImage(_enviroment.WebRootPath, "Assets/img");
            await _context.AboutWelcomes.AddAsync(welcome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            AboutWelcome? welcome = await _context.AboutWelcomes
                .Where(x => !x.IsDeleted && x.Id == id)
                 .FirstOrDefaultAsync();
            if (welcome == null)
                return NotFound();
            welcome.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            AboutWelcome? welcome = await _context.AboutWelcomes
                .Where(a => !a.IsDeleted && a.Id == id)
                 .FirstOrDefaultAsync();
            if(welcome == null) 
                return NotFound();
            return View(welcome);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,AboutWelcome welcome)
        {
            AboutWelcome? WelcomeUpdate = await _context.AboutWelcomes
                .Where(x => !x.IsDeleted && x.Id == id)
                 .FirstOrDefaultAsync();
            if (WelcomeUpdate == null)
                return NotFound();
            if (WelcomeUpdate.formFile == null)
            {
                WelcomeUpdate.Tittle = welcome.Tittle;
                WelcomeUpdate.Description=welcome.Description;
            }
            else
            {
                WelcomeUpdate.Tittle = welcome.Tittle;
                WelcomeUpdate.Description = welcome.Description;
                string image = welcome.formFile.CreateImage(_enviroment.WebRootPath, "Assets/img");
                WelcomeUpdate.Image = image;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
