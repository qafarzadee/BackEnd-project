using BackEndProcetMVC.Context;
using BackEndProcetMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Controllers
{   
    public class ContactController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        public ContactController(BackEndProjectDbContext context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
        {
            ContectViewModel model = new ContectViewModel()
            {
                adresses = await _context.adresses
                .Where(x => !x.IsDeleted)
                  .ToListAsync(),
                messages = await _context.AdressMessages.Where(x => !x.IsDeleted).ToListAsync()
            };
            return View(model);
        }

    }
}
