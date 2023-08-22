using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public EventController(BackEndProjectDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events=await _context.Events.Where(a=>!a.IsDeleted).ToListAsync();
            return View(events);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Event? eventt = await _context.Events.Where(x => !x.IsDeleted && x.Id == id)
                 .Include(x=>x.speakers)
                   .Include(x => x.EventTags)
                    .ThenInclude(x => x.Tag)
                     .FirstOrDefaultAsync();

            ViewBag.ExtraEvents = await _context.Events
                .Where(x => !x.IsDeleted && x.Id != id)
                 .Take(3)
                  .ToListAsync();

            return View(eventt);
        }
    }
}
