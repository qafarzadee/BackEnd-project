using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdressController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public AdressController(BackEndProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Adress> adreses = await _context.adresses.Where(z => !z.IsDeleted).ToListAsync();
            return View(adreses);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Adress adress)
        {
            await _context.adresses.AddAsync(adress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Adress? addres = await _context.adresses
                .Where(x => !x.IsDeleted && x.Id == id)
                  .FirstOrDefaultAsync();
            addres.IsDeleted=true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Adress? addres = await _context.adresses
                .Where(x => !x.IsDeleted && x.Id == id)
                  .FirstOrDefaultAsync();
            if (addres == null)
                return View();
            return View(addres);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Adress adress)
        {
            Adress? AddresUpdate = await _context.adresses
             .Where(x => !x.IsDeleted && x.Id == id)
               .FirstOrDefaultAsync();
            if (AddresUpdate == null)
                return View();
            AddresUpdate.PhoneNumber = adress.PhoneNumber;
            AddresUpdate.Adresss = adress.Adresss;
            AddresUpdate.Country=adress.Country;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
