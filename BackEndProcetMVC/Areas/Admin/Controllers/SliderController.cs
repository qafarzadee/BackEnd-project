using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using BackEndProcetMVC.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly BackEndProjectDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public SliderController(BackEndProjectDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider>?  sliders=await _context.sliders
                .Where(x=>!x.IsDeleted)
                  .ToListAsync();
            return View(sliders);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            slider.Image = slider.formFile.CreateImage(_enviroment.WebRootPath,"Assets/img");
            await _context.sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Slider? slider=await _context.sliders
                .Where(x=>!x.IsDeleted && x.Id==id)
                  .FirstOrDefaultAsync();
            if (slider == null)
                return NotFound();
            slider.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Slider? slider=await _context.sliders
                .Where(a=>!a.IsDeleted && a.Id==id)
                 .FirstOrDefaultAsync();
            if (slider == null)
                return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Slider slider)
        {
            if(!ModelState.IsValid) 
                return View();
            Slider? sliderToUpdate = await _context.sliders
                .Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
            if(sliderToUpdate == null) 
                return NotFound();
            if (slider.Title == null)
            {
                sliderToUpdate.Description = slider.Description;
            }
            else if(slider.Description == null)
            {
                sliderToUpdate.Title = slider.Title;              
            }
            else
            {
                sliderToUpdate.Title = slider.Title;
                sliderToUpdate.Description = slider.Description;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
