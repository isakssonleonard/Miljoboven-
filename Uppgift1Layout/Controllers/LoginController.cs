using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Uppgift1Layout.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Uppgift1Layout.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: /<controller>/

        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public LoginController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> siginMgr)
        {
            _userManager = userMgr;
            _signInManager = siginMgr;
        }

        [AllowAnonymous]
        public ViewResult Login(string retunrUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = retunrUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(loginModel.Name);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        
                        // användare loggar in som samordnare
                        if (await _userManager.IsInRoleAsync(user, "coordinator"))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Coordinator/Startcoordinator");
                        }

                        // användaren loggar in som handläggare
                        else if (await _userManager.IsInRoleAsync(user, "investigator"))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Investigator/Startinvestigator");
                        }

                        // användaren loggar in som chef
                        else if (await _userManager.IsInRoleAsync(user, "manager"))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Manager/Startmanager");
                        }
                    }                   
                }

            }

            // görs om inmatningen är ogiltig
            ModelState.AddModelError("", "Ogiltigt användarnamn eller lösenord");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
