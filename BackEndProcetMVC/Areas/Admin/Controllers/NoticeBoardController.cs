using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NoticeBoardController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public NoticeBoardController(BackEndProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<NoticeBoard> NoticeBoards = await _context.NoticeBoards
                .Where(a => !a.IsDeleted)
                  .ToListAsync();
            return View(NoticeBoards);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoticeBoard board)
        {
            board.CreatedDate=DateTime.Now;
            await _context.AddAsync(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            NoticeBoard? board=await _context.NoticeBoards
                .Where(a=>!a.IsDeleted && a.Id==id)
                  .FirstOrDefaultAsync();
            if (board == null)
                return NotFound();
            board.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            NoticeBoard? board = await _context.NoticeBoards
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
            if(board == null)
                return NotFound();
            return View(board);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,NoticeBoard board)
        {
            NoticeBoard? BoardUpdate=await _context.NoticeBoards
                .Where(a=>!a.IsDeleted && a.Id==id)
                  .FirstOrDefaultAsync();
            if(BoardUpdate==null)
                return NotFound();
            BoardUpdate.Description= board.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
