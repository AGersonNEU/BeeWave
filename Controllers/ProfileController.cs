using BeeWave.Data;
using BeeWave.Interfaces;
using BeeWave.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Security.Claims;

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
            // currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //profile.UserID = currentUserId;
            dal.AddProfile(profile);

            var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(profile.ProfileID), dal.GetAllPostsForPage(dal.GetProfile(1).UserID), dal.GetAllMessagesForPage(1));
            return RedirectToAction("MyPage", viewModel);   
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
            var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(profile.ProfileID), dal.GetAllPostsForPage(dal.GetProfile(profile.ProfileID).UserID), dal.GetAllMessagesForPage(profile.ProfileID));
            return View("~/Views/SitePages/MyPage.cshtml", viewModel);
        }

      
        public IActionResult OthersPage(string name)
        {

            //string currentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile foundProfile = dal.GetProfileByName(name);

            if(foundProfile.UserID == 1)
            {
                var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(foundProfile.ProfileID), dal.GetAllPostsForPage(dal.GetProfile(foundProfile.ProfileID).UserID), dal.GetAllMessagesForPage(foundProfile.ProfileID));
                return View("~/Views/SitePages/MyPage.cshtml", viewModel);
            }
            else
            {
                var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(foundProfile.ProfileID), dal.GetAllPostsForPage(dal.GetProfile(foundProfile.ProfileID).UserID), dal.GetAllMessagesForPage(foundProfile.ProfileID));
                return View("~/Views/SitePages/OthersPage.cshtml", viewModel);
            }
        }

        
        public IActionResult SearchResults(string name)
        {
            if(string.IsNullOrEmpty(name) || name == "")
            {
                return View("~/Views/SitePages/SearchResults.cshtml", dal.GetProfiles());
            }
            else
            {
                return View("~/Views/SitePages/SearchResults.cshtml", dal.GetProfilesByName(name));
            }
        }

        public IActionResult MyPage() 
        {
            //string currentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(1), dal.GetAllPostsForPage(1), dal.GetAllMessagesForPage(1));
            return View("~/Views/SitePages/MyPage.cshtml", viewModel);
        }

        [HttpGet]
        public IActionResult LeaveMessage(int id)
        {
            //pageId == int
            ViewBag.PageId = id;
            //get the id of the person who is logged in
            ViewBag.PosterName = dal.GetProfile(1).Name;
            //@ViewBad.ProfileId


          
            return View("~/Views/SitePages/LeaveMessage.cshtml");
        }

        [HttpPost]
        public IActionResult LeaveMessage(Message message)
        {
            //pageId == int
            //add an if that checks if it is my page or another persons page

            dal.AddMessage(message);
            var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(message.PageId), dal.GetAllPostsForPage(dal.GetProfile(message.PageId).UserID), dal.GetAllMessagesForPage(message.PageId));
            if (message.PageId == 1)
            {
                //var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(foundProfile.ProfileID), dal.GetAllPostsForPage(dal.GetProfile(foundProfile.ProfileID).UserID), dal.GetAllMessagesForPage(foundProfile.ProfileID));
                return View("~/Views/SitePages/MyPage.cshtml", viewModel);
            }
            else
            {
                //var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(foundProfile.ProfileID), dal.GetAllPostsForPage(dal.GetProfile(foundProfile.ProfileID).UserID), dal.GetAllMessagesForPage(foundProfile.ProfileID));
                return View("~/Views/SitePages/OthersPage.cshtml", viewModel);
            }
        }

        [HttpGet]
        public IActionResult MakePost(int id)
        {

            ViewBag.PageId = id;
            ViewBag.PosterId = id;
            ViewBag.PosterName = dal.GetProfile(id).Name;
            return View("~/Views/SitePages/MakePost.cshtml");
        }

        [HttpPost]
        public IActionResult MakePost(Post post)
        {
            dal.AddPost(post);
            var viewModel = new OneProfileAndPostsAndMessages(dal.GetProfile(1), dal.GetAllPostsForPage(1), dal.GetAllMessagesForPage(1));
            return View("~/Views/SitePages/MyPage.cshtml", viewModel);
        }

     
        public IActionResult WaveFeed()
        {
          
            return View("~/Views/SitePages/WaveFeed.cshtml", dal.GetAllPosts());
        }
    }
}
