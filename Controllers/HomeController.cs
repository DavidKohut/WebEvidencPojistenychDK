using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebEvidencPojistenychDK.Models;

namespace WebEvidencPojistenychDK.Controllers
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

        public IActionResult Contact() 
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult AboutApp()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
