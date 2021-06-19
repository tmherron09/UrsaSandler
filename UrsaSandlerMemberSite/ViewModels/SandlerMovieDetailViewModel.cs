using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;
using UrsaSandlerMemberSite.Services;

namespace UrsaSandlerMemberSite.ViewModels
{
    public class SandlerMovieDetailViewModel
    {
        public SandlerMovie SandlerMovie;
        public List<Actor> StarringActors;
        public List<Actor> CoStarringActors;
        public List<Actor> GuestActors;
        public List<MovieComment> MovieComments;
        public double? MovieRating;
        public SandlerMovieRating ClubUserRating;


        public SandlerMovieDetailViewModel(SandlerMovie sandlerMovie, List<Actor> starringActors, List<Actor> coStarringActors, List<Actor> guestActors, List<MovieComment> movieComments)
        {
            SandlerMovie = sandlerMovie;
            StarringActors = starringActors;
            CoStarringActors = coStarringActors;
            GuestActors = guestActors;
            MovieComments = movieComments;
        }

        public SandlerMovieDetailViewModel(SandlerMovie sandlerMovie, string clubMemberId, DataService dataService)
        {
            SandlerMovie = sandlerMovie;
            MovieComments = dataService.GetMovieCommentsById(sandlerMovie.Id).ToList();
            MovieRating = dataService.GetMovieRating(sandlerMovie.Id);
            StarringActors = dataService.GetMovieStarringRolesById(sandlerMovie.Id).ToList();
            CoStarringActors = dataService.GetMovieCoStarsById(sandlerMovie.Id).ToList();
            GuestActors = dataService.GetMovieGuestAppearencesById(sandlerMovie.Id).ToList();
            ClubUserRating = dataService.GetMovieRatingByUser(SandlerMovie.Id, clubMemberId);
        }

    }
}
