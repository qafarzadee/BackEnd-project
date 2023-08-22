using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public EventController(BackEndProjectDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await _context.Events
                .Where(x => !x.IsDeleted)
                 .ToListAsync();
            return View(events);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Speakers = await _context.speakers.Where(x => !x.IsDeleted).ToListAsync();
            ViewBag.Tags=await _context.tags.Where(a=>!a.IsDeleted).ToListAsync();
            return View();
        }

       public async Task<IActionResult> Create(Event eventt)
        {
            if(eventt.FormFile==null)
            {
                ModelState.AddModelError(string.Empty, "image is required!");
                return View();
            }
            eventt.Image = eventt.FormFile.CreateImage(_environment.WebRootPath, "Assets/img");
            if (eventt.SpeakerIds == null)
                return View();


            foreach (var item in eventt.TagIds)
            {
                EventTag eventTag = new EventTag()
                {
                    Event=eventt,
                    TagId=item
                };
                await _context.EventTags.AddAsync(eventTag);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Event? eventt=await _context.Events
                 .Where(x=>!x.IsDeleted && x.Id==id)
                   .FirstOrDefaultAsync();
            if (eventt == null)
                return NotFound();
            eventt.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
