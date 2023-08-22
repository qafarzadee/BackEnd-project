using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageInfoController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public PageInfoController(BackEndProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PageInfo> pageInfos = await _context.pageInfoos.Where(a => !a.IsDeleted).ToListAsync();
            return View(pageInfos);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PageInfo pageInfo)
        {
           
            await _context.AddAsync(pageInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            PageInfo? info=await _context.pageInfoos.Where(a=>!a.IsDeleted && a.Id==id).FirstOrDefaultAsync();
            return View(info);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,PageInfo info)
        {
            PageInfo pageInfo=await _context.pageInfoos.Where(a=>!a.IsDeleted && a.Id==id).FirstOrDefaultAsync();
            pageInfo.Twitter=info.Twitter;
            pageInfo.Email=info.Email;
            pageInfo.Adress=info.Adress;
            pageInfo.Detail=info.Detail;
            pageInfo.PhoneNumber=info.PhoneNumber;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
