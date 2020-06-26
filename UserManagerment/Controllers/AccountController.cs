using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using UserManagerment.Models;

namespace UserManagerment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManagerContext _context;
        public AccountController(UserManagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel input)
        {
            // check user has on database with user and pass
            var user = _context.Users.FirstOrDefault(x => x.UserName == input.LoginName && x.PassWord == input.Password);
            if (user!=null)// check if user and pass coorect so add authen to cookie and redirect to user manager page
            {
                var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, user.UserName)
             };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // add info authorize user into cookie
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = input.RememberMe
                    });
                // redirect to page user managerment
                return RedirectToAction("Index", "Users");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
        }
    }
}