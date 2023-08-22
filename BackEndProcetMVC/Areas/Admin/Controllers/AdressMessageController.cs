using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdressMessageController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public AdressMessageController(BackEndProjectDbContext context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<AdressMessage> messages = await _context.AdressMessages
                .Where(x => !x.IsDeleted).ToListAsync();
            return View(messages);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdressMessage message)
        {
            await _context.AdressMessages.AddAsync(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            AdressMessage? messagge = await _context.AdressMessages
                .Where(x=>!x.IsDeleted && x.Id==id)
                 .FirstOrDefaultAsync();
            if (messagge != null)
                return NotFound();
            return View(messagge);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,AdressMessage message)
        {
            AdressMessage? MessageUpdate = await _context.AdressMessages
            .Where(x => !x.IsDeleted && x.Id == id)
             .FirstOrDefaultAsync();
            if (MessageUpdate != null)
                return NotFound();
            MessageUpdate.Tittle=message.Tittle;
            MessageUpdate.Description=message.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            AdressMessage? message = await _context.AdressMessages.Where(x => x.Id == id).FirstOrDefaultAsync(); 
            message.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
