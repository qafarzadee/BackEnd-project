using BackEndMvcCore.Entities;
using BackEndProcetMVC.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProcetMVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class VideoController : Controller
	{
		private readonly BackEndProjectDbContext _context;
		public VideoController(BackEndProjectDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			List<Video> videos = await _context.videos
				.Where(x => x.Id == 1)
				  .ToListAsync();
			return View(videos);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Video video)
		{
			video.CreatedDate=DateTime.Now;
			await _context.videos.AddAsync(video);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			Video? video = await _context.videos
				.Where(x => x.Id == id)
				  .FirstOrDefaultAsync();
			if (video == null)
				return NotFound();
			return View(video);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id,Video video)
		{
			Video? videoUpdate = await _context.videos
				.Where(x => x.Id == id)
				  .FirstOrDefaultAsync();
			if(videoUpdate == null) 
				return NotFound();
			videoUpdate.Name= video.Name;
			videoUpdate.Link= video.Link;
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		
	}
}
