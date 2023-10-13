using Authentication_System_MVC.Models;
using Authentication_System_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Authentication_System_MVC.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Main() {
            return View();
        }
        [Route("/Reg")]
        public IActionResult RegistView()
        {
            return View();
        }
    }
}