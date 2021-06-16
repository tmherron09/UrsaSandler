using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;
using UrsaSandlerMemberSite.Services;

namespace UrsaSandlerMemberSite.Controllers
{
    [Authorize]
    public class MovieCommentController : Controller
    {
        private readonly UserManager<ClubMember> _userManager;
        private readonly DataService _dataService;

        public MovieCommentController(UserManager<ClubMember> userManager, DataService dataService)
        {
            _userManager = userManager;
            _dataService = dataService;
        }


        // POST: MovieCommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostComment(IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //MovieComment comment = new MovieComment();

            //if (!collection.TryGetValue("SandlerMovie.Id", out var formMovieId))
            //{
            //    return BadRequest();
            //}

            //comment.SandlerMovieId = Int32.Parse(formMovieId);
            //comment.ClubMemberId = _userManager.GetUserId(User);
            //comment.Comment = collection["postCommentData"];
            //comment.TimeStamp = DateTime.Now;

            MovieComment comment = await _dataService.CreateMovieCommentPost(collection, _userManager.GetUserId(User));
            if(comment == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Details", "SandlerMovies", new { id = comment.SandlerMovieId });

        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieCommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieCommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
