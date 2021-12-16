using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Begge.Services.DTOs;
using Begge.Services.Contracts;
using Begge.Common;

namespace Begge.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            this._auth = auth;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new RequestAuthDTO());
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(RequestAuthDTO model)
        {
            if (!await _auth.IsPasswordValidAsync(model.Email, model.Password))
            {
                ModelState.AddModelError("Password", Constants.WRONG_CREDENTIALS);
                return View(model);
            }
            var user = await _auth.GetByEmailAsync(model.Email);

            await SignInWithRoleAsync(model.Email, user.Role);

            return RedirectToAction("index", "home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Ok();
        }

        private async Task SignInWithRoleAsync(string email, string userRoleName)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Email, email));
            identity.AddClaim(new Claim(ClaimTypes.Role, userRoleName));


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
