using ASM_Auto.Data.Models;
using ASM_Auto.Services.Common;
using ASM_Auto.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASM_Auto.Web.Controllers
{
    public class AccountController : BaseController
    {
        public UserManager<User> userManager;
        public SignInManager<User> signInManager;
        public ICartService cartService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICartService cartService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cartService = cartService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated??false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          
            var user = await userManager.FindByEmailAsync(model.Email);
            
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Invalid login!");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var checkEmail  = await userManager.FindByEmailAsync(model.Email);

            if (checkEmail!=null)
            {
                ModelState.AddModelError("", "Вече съществува потребител с този Email!");
                return View(model);
            }
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
            {
                 
                 user.CartId = await cartService.CreateCart(user.Id);

                 await userManager.UpdateAsync(user);

                await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                return RedirectToAction("Index", "Home");
                
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }

            return View(model);

        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Възникна грешка!");
                return View(model);
            }
            var user = await userManager.FindByIdAsync(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            if (user==null)
            {
                ModelState.AddModelError("", "Няма логнат потребител! Моля влезте отново!");
                return View(model);
            }


           var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.First().Description);
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
