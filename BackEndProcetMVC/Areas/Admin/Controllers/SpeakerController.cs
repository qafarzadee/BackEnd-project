using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakerController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public SpeakerController(BackEndProjectDbContext context, IWebHostEnvironment enviroment)
        {
            _context= context;
            _enviroment= enviroment;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Speaker> speakers = await _context.speakers
                .Where(x => !x.IsDeleted)
                  .ToListAsync();
            return View(speakers);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Speaker speaker)
        {
            if(speaker.formFile== null)
            {
                ModelState.AddModelError(string.Empty, "you must enter an image!");
                return View();
            }
            speaker.Image = speaker.formFile.CreateImage(_enviroment.WebRootPath, "Assets/img");
            await _context.speakers.AddAsync(speaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Speaker? speaker = await _context.speakers
                .Where(x => !x.IsDeleted && x.Id == id)
                  .FirstOrDefaultAsync();
            if (speaker == null)
                return NotFound();
            speaker.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Speaker? speaker = await _context.speakers
                .Where(x => !x.IsDeleted && x.Id == id)
                  .FirstOrDefaultAsync();
            if (speaker == null)
                return NotFound();
            return View(speaker);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Speaker speaker)
        {
            Speaker? SpeakerUpdate = await _context.speakers
              .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
            if (speaker == null)
                return NotFound();
            if (speaker.formFile != null)
            {

            SpeakerUpdate.Image = speaker.formFile.CreateImage(_enviroment.WebRootPath, "Assets/img");
            SpeakerUpdate.Fullname = speaker.Fullname;
            SpeakerUpdate.Position = speaker.Position;
            }
            else
            {
                SpeakerUpdate.Fullname = speaker.Fullname;
                SpeakerUpdate.Position = speaker.Position;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
