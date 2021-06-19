using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Data;
using UrsaSandlerMemberSite.Models;
using UrsaSandlerMemberSite.ViewModels;

namespace UrsaSandlerMemberSite.Services
{

    // Temp service to serve as replacement for IRepository given scaled scope.
    public class DataService
    {

        public readonly ApplicationDbContext _context;
        public readonly ImageService _imageService;
        public DataService(ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public List<SandlerMovie> GetAllSandlerMovies() => _context.SandlerMovies.ToList();

        public SandlerMovie GetMovieById(int id) =>
            _context.SandlerMovies.Where(sm => sm.Id == id).FirstOrDefault();

        public List<SandlerMovie> GetMoviesAlphabetically() => _context.SandlerMovies.OrderBy(m => m.Title).ToList();

        public List<Actor> GetAllActors() =>
            _context.Actors.ToList();
        public Actor GetActorById(int id) =>
            _context.Actors.Where(a => a.Id == id).FirstOrDefault();


        public double? GetMovieRating(int sandlerMovieId)
        {
            var allRatings = _context.SandlerMovieRatings.Where(smr => smr.SandlerMovieId == sandlerMovieId);
            double tempRating = 0;
            foreach(var rating in allRatings)
            {
                tempRating += rating.Rating;
            }

            return tempRating / allRatings.Count();
        }
        public IEnumerable<MovieComment> GetMovieCommentsById(int sandlerMovieId) =>
            _context.MovieComments.Where(sm => sm.Id == sandlerMovieId).Include(sm => sm.CommentPoster);

        public async Task<MovieComment> CreateMovieCommentPost(IFormCollection collection, string userId)
        {
            MovieComment movieComment;
            if (!collection.TryGetValue("SandlerMovie.Id", out var formMovieId))
            {
                movieComment = null;
                return movieComment;
            }
            movieComment = new MovieComment();
            movieComment.SandlerMovieId = Int32.Parse(formMovieId);
            movieComment.ClubMemberId = userId;
            movieComment.Comment = collection["postCommentData"];
            movieComment.TimeStamp = DateTime.Now;

            try
            {
                await _context.MovieComments.AddAsync(movieComment);
                await _context.SaveChangesAsync();
            }
            catch
            {
                movieComment = null;
                return movieComment;
            }
            return movieComment;
        }

        public IEnumerable<Actor> GetMovieStarringRolesById(int sandlerMovieId) =>
            _context.ActorStarringRoles.Where(sr => sr.SandlerMovie.Id == sandlerMovieId).Select(sr => sr.Actor);

        public IEnumerable<Actor> GetMovieCoStarsById(int sandlerMovieId) =>
            _context.CoStarringRoles.Where(csr => csr.SandlerMovie.Id == sandlerMovieId).Select(csr => csr.CoStar);

        public IEnumerable<Actor> GetMovieGuestAppearencesById(int sandlerMovieId) =>
            _context.GuestAppearences.Where(ga => ga.SandlerMovie.Id == sandlerMovieId).Select(ga => ga.GuestStar);

        public IEnumerable<NewsPost> GetAllNewsPosts()
        {
            return _context.NewsPosts.Include(np => np.ClubMember).OrderByDescending(np=> np.Timestamp);
        }

        public IEnumerable<NewsPost> GetNewsPostsPage(int pageNumber, int amount) =>
            _context.NewsPosts.Include(np => np.ClubMember).OrderByDescending(np => np.Timestamp).Skip(pageNumber * amount).Take(amount);

        public IEnumerable<Meeting> GetAllMeetings() =>
            _context.Meetings.Include(m => m.MeetingMovie);
        public Meeting GetMeetingById(int meetingId) =>
            _context.Meetings.Where(m => m.Id == meetingId).Include(m => m.MeetingMovie).FirstOrDefault();

        public IEnumerable<ClubMember> GetAttendanceByMeetingId(int meetingId) =>
            _context.Attendance.Where(a => a.Meeting.Id == meetingId).Include(a => a.ClubMember).Select(a=> a.ClubMember);

        public IEnumerable<SandlerMovieRating> GetMovieRatingByMeetingId(int meetingId)
        {
            Meeting meeting = _context.Meetings.Where(m => m.Id == meetingId).FirstOrDefault();
            if(meeting == null)
            {
                return null;
            }

            var attendance = GetAttendanceByMeetingId(meetingId).Select(a=> a.Id);

            return _context.SandlerMovieRatings.Where(smr=> smr.SandlerMovieId == meeting.MeetingMovie.Id && attendance.Contains(smr.ClubMemberId)).AsEnumerable();
        }

        //public bool AssignActorRole(SandlerMovie sandlerMovie, Actor actor, AssignActorViewModel.AssignType assignmentType)
        //{

        //}

        public async Task<bool> AssignActorRole(AssignActorViewModel viewModel)
        {
            viewModel.SandlerMovie = GetMovieById(viewModel.SandlerMovieId);
            viewModel.Actor = GetActorById(viewModel.ActorId);

            if (viewModel.SandlerMovie == null || viewModel.Actor == null)
            {
                return false;
            }

            try
            {
                switch (viewModel.AssignmentType)
                {
                    case AssignActorViewModel.AssignType.StarringRole:
                        ActorStarringRole actorRole = new ActorStarringRole() { Actor = viewModel.Actor, SandlerMovie = viewModel.SandlerMovie };
                        await _context.ActorStarringRoles.AddAsync(actorRole);
                        break;
                    case AssignActorViewModel.AssignType.CoStarringRole:
                        CoStarringRole coStarringRole = new CoStarringRole() { CoStar = viewModel.Actor, SandlerMovie = viewModel.SandlerMovie };
                        await _context.CoStarringRoles.AddAsync(coStarringRole);
                        break;
                    case AssignActorViewModel.AssignType.GuestAppearence:
                        GuestAppearence guestAppearence = new GuestAppearence() { GuestStar = viewModel.Actor, SandlerMovie = viewModel.SandlerMovie };
                        await _context.GuestAppearences.AddAsync(guestAppearence);
                        break;
                    default:
                        throw new ArgumentException("Invalid Enum Value");
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> AssignActorRole(int sandlerMovieId, int actorId, AssignActorViewModel.AssignType assignmentType)
        {
            var sandlerMovie = GetMovieById(sandlerMovieId);
            var actor = GetActorById(actorId);

            if (sandlerMovie == null || actor == null)
            {
                return false;
            }

            try
            {
                switch (assignmentType)
                {
                    case AssignActorViewModel.AssignType.StarringRole:
                        ActorStarringRole actorRole = new ActorStarringRole() { Actor = actor, SandlerMovie = sandlerMovie };
                        await _context.ActorStarringRoles.AddAsync(actorRole);
                        break;
                    case AssignActorViewModel.AssignType.CoStarringRole:
                        CoStarringRole coStarringRole = new CoStarringRole() { CoStar = actor, SandlerMovie = sandlerMovie };
                        await _context.CoStarringRoles.AddAsync(coStarringRole);
                        break;
                    case AssignActorViewModel.AssignType.GuestAppearence:
                        GuestAppearence guestAppearence = new GuestAppearence() { GuestStar = actor, SandlerMovie = sandlerMovie };
                        await _context.GuestAppearences.AddAsync(guestAppearence);
                        break;
                    default:
                        throw new ArgumentException("Invalid Enum Value");
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public string GetUserFirstName(string userEmail)
        {
            ClubMember clubUser = _context.Users.Where(u => u.Email == userEmail).FirstOrDefault();

            return clubUser.FirstName;
        }

        public Meeting GetThisWeeksMeeting() => _context.Meetings.Where(m => m.MeetingDate.Date >= DateTime.Today.Date).OrderBy(m => m.MeetingDate).Include(m=> m.Attenance).Include(m=> m.MeetingMovie).FirstOrDefault();

        public SandlerMovieRating GetMovieRatingByUser(int movieId, string userId) => _context.SandlerMovieRatings.Where(smr => smr.SandlerMovieId == movieId && smr.ClubMemberId == userId).FirstOrDefault();


        // Creational

        public async Task AddNewSandlerMovieAsync(SandlerMovie sandlerMovie)
        {
            sandlerMovie.PosterUrl = await _imageService.GetMoviePostUrl(sandlerMovie.Title);
            await _context.AddAsync(sandlerMovie);
            await _context.SaveChangesAsync();
        }

        public async Task AddActorAsync(Actor actor)
        {
            actor.ImageUrl = await _imageService.GetActorPhoto(actor.FullName);
            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewsPostAsync(NewsPost post)
        {
            await _context.NewsPosts.AddAsync(post);
            await _context.SaveChangesAsync();
        }
    
        public async Task AddMeetingAsync(Meeting meeting)
        {
            await _context.Meetings.AddAsync(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task AddMovieRatingAsync(SandlerMovieRating movieRating)
        {
            var previousRating = _context.SandlerMovieRatings.Where(smr => smr.ClubMemberId == movieRating.ClubMemberId && smr.SandlerMovieId == movieRating.SandlerMovieId).FirstOrDefault();


            if (previousRating == null)
            {
                await _context.SandlerMovieRatings.AddAsync(movieRating);
                
            } else
            {
                previousRating.Rating = movieRating.Rating;
                _context.SandlerMovieRatings.Update(previousRating);
            }
            await _context.SaveChangesAsync();
        }

    }

}
