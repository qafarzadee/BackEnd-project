using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Controllers
{
    public class TagController : Controller
    {
        private  readonly BackEndProjectDbContext _context;
        public TagController(BackEndProjectDbContext context)
        {
            _context = context;
        }
       public async Task<IActionResult> Detail(int id)
        {
            ViewBag.ExtraEvents = await _context.Events.Where(x => !x.IsDeleted).Take(3).ToListAsync();

            Tag? tag = await _context.tags
                .Where(x => !x.IsDeleted && x.Id == id)
                 .FirstOrDefaultAsync();
            return View(tag);
        }

    }
}
