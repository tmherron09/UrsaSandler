using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;

namespace UrsaSandlerMemberSite.Controllers
{
    public class HomeController : Controller
    {
        public readonly SignInManager<ClubMember> _signInManager;

        public HomeController(SignInManager<ClubMember> signInManager)
        {
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            if(!_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("Index");
            }

            return View("Home");
        }

        [Authorize]
        public IActionResult Home() => View();
    }
}
