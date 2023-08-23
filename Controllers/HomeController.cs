using BeeWave.Interfaces;
using BeeWave.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeeWave.Controllers
{
    public class HomeController : Controller
    {
       
        IDataAccessLayer dal;
        public HomeController(IDataAccessLayer indal)
        {
            dal = indal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutMe()
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