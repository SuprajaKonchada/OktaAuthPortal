using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OktaAuthPortal.Models;
using System.Diagnostics;

namespace OktaAuthPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Displays the admin page. Only accessible to users with the "Application Administrator" role.
        /// </summary>
        /// <returns>View for the admin page.</returns>
        [Authorize(Roles = "Application Administrator")]
        public IActionResult AdminPage()
        {
            return View();
        }

        /// <summary>
        /// Displays the user page. Only accessible to users with the "Group Administrator" role.
        /// </summary>
        /// <returns>View for the user page.</returns>

        [Authorize(Roles = "Group Administrator")]
        public IActionResult UserPage()
        {
            return View();
        }

    }
}
