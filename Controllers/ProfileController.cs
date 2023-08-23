using BeeWave.Interfaces;
using BeeWave.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeeWave.Controllers
{
    public class ProfileController : Controller
    {
        IDataAccessLayer dal;
        public ProfileController(IDataAccessLayer indal)
        {
            dal = indal;
        }

        [HttpGet]
        public IActionResult CreateProfile() 
        { 
            return View("~/Views/SitePages/CreateProfile.cshtml");
        }

        [HttpPost]
        public IActionResult CreateProfile(Profile profile)
        {
            dal.AddProfile(profile);
            return RedirectToAction("MyPage", profile);   
        }

        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            Profile profile = dal.GetProfile(id);
            return View("~/Views/SitePages/EditProfile.cshtml",profile);
        }

        [HttpPost]
        public IActionResult EditProfile(Profile profile)
        {
            dal.EditProfile(profile);
            return View("~/Views/SitePages/MyPage.cshtml",profile);
        }

        [HttpGet]
        public IActionResult OthersPage(Profile profile)
        {
            return View(profile);
        }
       
        public IActionResult MyPage() 
        {
            Profile testProfile = dal.GetProfile(1);
            return View("~/Views/SitePages/MyPage.cshtml", testProfile);
        }
    }
}
