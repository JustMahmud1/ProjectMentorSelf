using MentorProject.Models;
using MentorProject.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MentorProject.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            AppUser? user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
            }

            var result = await _signInManager.PasswordSignInAsync(user,loginVM.Password,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("","Email or Password is incorrect");
                return View();
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            AppUser user = new AppUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
            };



            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
				return View();

			}

			await _userManager.AddToRoleAsync(user, "member");

            return RedirectToAction("Login","Account");
        }

        public IActionResult Logout()
        {
            return RedirectToAction();
        }


        public async Task<IActionResult> CreateRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole("member"));
            await _roleManager.CreateAsync(new IdentityRole("admin"));
            await _roleManager.CreateAsync(new IdentityRole("superadmin"));

            return Ok();
        }

    }
}
