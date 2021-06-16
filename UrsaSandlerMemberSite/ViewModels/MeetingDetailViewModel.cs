using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;
using UrsaSandlerMemberSite.Services;

namespace UrsaSandlerMemberSite.ViewModels
{
    public class MeetingDetailViewModel
    {
        public Meeting Meeting { get; set; }
        public SandlerMovie SandlerMovie;
        public List<Actor> StarringActors;
        public List<Actor> CoStarringActors;
        public List<Actor> GuestActors;
        public List<MovieComment> MovieComments;
        public List<SandlerMovieRating> AttendanceMovieRatings { get; set; }


        public double? MovieRating;
        public List<ClubMember> MeetingAttendance { get; set; }

        public MeetingDetailViewModel(Meeting meeting, DataService dataService)
        {
            Meeting = meeting;
            SandlerMovie = meeting.MeetingMovie;
            MovieComments = dataService.GetMovieCommentsById(SandlerMovie.Id).ToList();
            MovieRating = dataService.GetMovieRating(SandlerMovie.Id);
            StarringActors = dataService.GetMovieStarringRolesById(SandlerMovie.Id).ToList();
            CoStarringActors = dataService.GetMovieCoStarsById(SandlerMovie.Id).ToList();
            GuestActors = dataService.GetMovieGuestAppearencesById(SandlerMovie.Id).ToList();
            MeetingAttendance = dataService.GetAttendanceByMeetingId(Meeting.Id).ToList();
            AttendanceMovieRatings = dataService.GetMovieRatingByMeetingId(Meeting.Id).ToList();
        }

    }
}
