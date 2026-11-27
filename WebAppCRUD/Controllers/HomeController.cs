using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : AbstractController(logger)
    {
        


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Settings()
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
    }
}
