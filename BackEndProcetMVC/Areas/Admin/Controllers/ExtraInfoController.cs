using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExtraInfoController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public ExtraInfoController(BackEndProjectDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ExtraInfo> extraInfos = await _context.ExtraInfos
                .Where(x => !x.IsDeleted)
                  .ToListAsync();
            return View(extraInfos);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExtraInfo extraInfo)
        {
            extraInfo.Image = extraInfo.formFile.CreateImage(_enviroment.WebRootPath, "Assets/img");
            await _context.ExtraInfos.AddAsync(extraInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ExtraInfo? extra = await _context.ExtraInfos
                .Where(x => !x.IsDeleted && x.Id == id)
                 .FirstOrDefaultAsync();
            if (extra == null)
                return NotFound();
            extra.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            ExtraInfo? info = await _context.ExtraInfos
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
            if(info == null) return NotFound();
            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ExtraInfo extra)
        {
            ExtraInfo? info = await _context.ExtraInfos
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
            if(info == null)
                return NotFound();
            info.Image = extra.formFile.CreateImage(_enviroment.WebRootPath, "Assets/img");
            info.Position = extra.Position;
            info.Description = extra.Description;
            info.Name = extra.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
