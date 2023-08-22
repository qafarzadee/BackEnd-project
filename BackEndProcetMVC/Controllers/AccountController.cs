using BackEndMvcCore.Entities;
using BackEndProcetMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProcetMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> UserManager, SignInManager<AppUser> signInManager)
        {
            _userManager = UserManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegsiterViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            AppUser user = new AppUser()
            {
                Name= model.Name,
                Email = model.Email,
                UserName= model.UserName,
                Surname=model.Surname
            };
            var result=await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(model);
            }
            await _userManager.AddToRoleAsync(user, "User");
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public async Task<IActionResult> Logous()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public async Task<IActionResult> Info()
        {
            string username = User.Identity.Name;
            AppUser user=await _userManager.FindByNameAsync(username);
            return View(user);
        }
    }
}
