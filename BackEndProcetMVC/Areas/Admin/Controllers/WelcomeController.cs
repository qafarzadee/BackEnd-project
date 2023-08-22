using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WelcomeController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public WelcomeController(BackEndProjectDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Welcome> welcomes = await _context.welcomes
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Welcome welcome)
        {
            welcome.Image = welcome.Formfile.CreateImage(_environment.WebRootPath,"Assets/img");
            await _context.welcomes.AddAsync(welcome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Welcome? welcome = await _context.welcomes
                .Where(x => !x.IsDeleted && x.Id == id)
                 .FirstOrDefaultAsync();
            if(welcome==null)
                return NotFound();
            welcome.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Welcome? welcome = await _context.welcomes
                .Where(x => !x.IsDeleted && x.Id == id)
                  .FirstOrDefaultAsync();
            if(welcome==null) 
                return NotFound();
            return View(welcome);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Welcome welcome)
        {
        
            Welcome? WelcomeUpdate = await _context.welcomes
                .Where(a => !a.IsDeleted && a.Id == id)
                  .FirstOrDefaultAsync();
            if (welcome.Formfile == null)
            {
                WelcomeUpdate.Tittle = welcome.Tittle;
                WelcomeUpdate.Description= welcome.Description;
            }
            else if(welcome.Formfile != null)
            {
                WelcomeUpdate.Tittle = welcome.Tittle;
                WelcomeUpdate.Description = welcome.Description;
                WelcomeUpdate.Image = welcome.Formfile.CreateImage(_environment.WebRootPath, "Assets/img");
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
