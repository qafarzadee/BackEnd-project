using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public TagController(BackEndProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Tag> tags = await _context.tags
                .Where(x => !x.IsDeleted)
                  .ToListAsync();
            return View(tags);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (tag.Name == null)
                return View();
            await _context.tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Tag? tag=await _context.tags
                .FindAsync(id);
            if (tag == null)
                return NotFound();
            tag.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Tag? tag=await _context.tags
                .FindAsync(id);
            if(tag==null)
                return NotFound();
            return View(tag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Tag tag)
        {
            Tag? TagUpdate=await _context.tags
                .FindAsync(id);
            if(TagUpdate==null)
                return NotFound();
            TagUpdate.Name= tag.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
