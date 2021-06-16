using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;
        private readonly UserManager<ClubMember> _userManager;


        public MeetingsController(ApplicationDbContext context, DataService dataService, UserManager<ClubMember> userManager)
        {
            _context = context;
            _dataService = dataService;
            _userManager = userManager;
        }

        // GET: Meetings
        public IActionResult Index()
        {
            return View(_dataService.GetAllMeetings());
        }

        // GET: Meetings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = _dataService.GetMeetingById(id ?? -1);
            if (meeting == null)
            {
                return NotFound();
            }

            MeetingDetailViewModel viewModel = new MeetingDetailViewModel(meeting, _dataService);

            return View(viewModel);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            CreateMeetingViewModel viewModel = new CreateMeetingViewModel(_dataService);

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingDate,SandlerMovieId ")] CreateMeetingViewModel meetingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Meeting meeting = new Meeting();
            meeting.MeetingDate = meetingViewModel.MeetingDate;
            meeting.MeetingMovie = _dataService.GetMovieById(meetingViewModel.SandlerMovieId);


            try
            {
                await _dataService.AddMeetingAsync(meeting);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> MarkAttended(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var clubMemberId = _userManager.GetUserId(User);

            if (_context.Attendance.Where(a=> a.ClubMember.Id == clubMemberId && a.Meeting.Id == id).FirstOrDefault() != null)
            {
                return RedirectToAction(nameof(Details), new { id = id });
            }
            Attendance attendance = new Attendance();
            attendance.Meeting = _dataService.GetMeetingById(id);
            attendance.ClubMember = _context.Users.Where(u => u.Id == clubMemberId).FirstOrDefault();
            try
            {
                await _context.Attendance.AddAsync(attendance);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }

            return RedirectToAction(nameof(Details), new { id = id });

        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingDate")] Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.Id))
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
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meetings.Any(e => e.Id == id);
        }
    }
}
