using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UrsaSandlerMemberSite.Data;
using UrsaSandlerMemberSite.Models;
using UrsaSandlerMemberSite.Services;
using UrsaSandlerMemberSite.ViewModels;

namespace UrsaSandlerMemberSite.Controllers
{
    [Authorize]
    public class SandlerMoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ClubMember> _userManager;
        private readonly DataService _dataService;

        public SandlerMoviesController(ApplicationDbContext context, UserManager<ClubMember> userManager, DataService dataService)
        {
            _context = context;
            _userManager = userManager;
            _dataService = dataService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SandlerMovies.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View(nameof(Index));
            }

            var sandlerMovie = await _context.SandlerMovies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sandlerMovie == null)
            {
                return NotFound();
            }

            SandlerMovieDetailViewModel movieViewModel = new SandlerMovieDetailViewModel(sandlerMovie, _dataService);

            return View(movieViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IsHappyMadison,ReleaseDate,Synonpsis")] SandlerMovie sandlerMovie)
        {
            if (ModelState.IsValid)
            {

                await _dataService.AddNewSandlerMovieAsync(sandlerMovie);
                
                return RedirectToAction(nameof(Index));
            }
            return View(sandlerMovie);
        }

        [HttpGet]
        public IActionResult AssignActor(int id)
        {
            var sandlerMovie = _dataService.GetMovieById(id);
            if (sandlerMovie == null)
            {
                return NotFound();
            }

            AssignActorViewModel assignActorViewModel = new AssignActorViewModel();
            assignActorViewModel.SandlerMovie = sandlerMovie;
            assignActorViewModel.SandlerMovieId = id;

            return View(assignActorViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignActor([FromForm(Name = "SandlerMovieId")] int sandlerMovieId, [FromForm(Name = "AssignmentType")] AssignActorViewModel.AssignType assignmentType, [FromForm(Name = "ActorId")] int actorId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(await _dataService.AssignActorRole(sandlerMovieId, actorId, assignmentType))
            {
                return RedirectToAction(nameof(Details), new { id = sandlerMovieId });
            }
            else
            {
                return BadRequest();
            }

            
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sandlerMovie = await _context.SandlerMovies.FindAsync(id);
            if (sandlerMovie == null)
            {
                return NotFound();
            }
            return View(sandlerMovie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,IsHappyMadison,ReleaseDate,Synonpsis")] SandlerMovie sandlerMovie)
        {
            if (id != sandlerMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sandlerMovie.PosterUrl = HttpUtility.UrlEncode(sandlerMovie.PosterUrl);

                    _context.Update(sandlerMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SandlerMovieExists(sandlerMovie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sandlerMovie);
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    // TODO: Secure app to general public.

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sandlerMovie = await _context.SandlerMovies
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (sandlerMovie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sandlerMovie);
        //}

        //// POST: SandlerMovies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    // Removed until secure. Anyone can join site.
        //    //var sandlerMovie = await _context.SandlerMovies.FindAsync(id);
        //    //_context.SandlerMovies.Remove(sandlerMovie);
        //    // await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SandlerMovieExists(int id)
        {
            return _context.SandlerMovies.Any(e => e.Id == id);
        }
    }
}
