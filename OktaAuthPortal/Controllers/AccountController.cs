using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace OktaAuthPortal.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Displays the index page of the Account Controller.
        /// </summary>
        /// <returns>View for the index page.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Initiates the login process by challenging the OpenID Connect authentication scheme.
        /// The user is redirected to the Okta login page.
        /// </summary>
        /// <returns>Redirects the user to the specified URI after login.</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Signs the user out by clearing their cookies and ending the OpenID Connect session.
        /// The user is then redirected to the home page.
        /// </summary>
        /// <returns>Redirects the user to the specified URI after logout.</returns>
        [HttpGet]
        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
