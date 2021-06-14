using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;

namespace UrsaSandlerMemberSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        readonly SignInManager<ClubMember> _signInManager;

        public IndexModel(ILogger<IndexModel> logger, SignInManager<ClubMember> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            if(_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Home", "Home");
            }

            return null;

        }
    }
}
