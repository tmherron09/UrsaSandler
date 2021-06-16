using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;
using UrsaSandlerMemberSite.Services;
using UrsaSandlerMemberSite.ViewModels;

namespace UrsaSandlerMemberSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<ClubMember> _signInManager;
        private readonly UserManager<ClubMember> _userManager;
        private readonly DataService _dataService;

        public HomeController(SignInManager<ClubMember> signInManager, DataService dataService, UserManager<ClubMember> userManager)
        {
            _signInManager = signInManager;
            _dataService = dataService;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("Index");
            }

            return View("Home");
        }

        [Authorize]
        public IActionResult Home()
        {
            HomeViewModel model = new HomeViewModel();
            model.ThisWeekMeeting = _dataService.GetThisWeeksMeeting();
            model.NewsPosts = _dataService.GetAllNewsPosts().ToList();

            return View(model);
        }


        [Authorize]
        public IActionResult NewPost()
        {
            NewsPost newPost = new NewsPost();

            return View(newPost);
        }

        [Authorize]
        public async Task<IActionResult> NewPost([Bind("Title, BodyText, ImageUrl")] NewsPost post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            post.Timestamp = DateTime.Now;
            post.ClubMember = await _userManager.GetUserAsync(User);

            try
            {
                await _dataService.AddNewsPostAsync(post);
            }
            catch
            {
                throw new Exception("Invalid post");
            }

            return RedirectToAction(nameof(Home));
        }

    }
}
