using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class SandlerMovie
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Movie title required.")]
        public string Title { get; set; }
        [Display(Name = "Happy Madison production")]
        public bool IsHappyMadison { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }
        public string Synonpsis { get; set; }
        public string PosterUrl { get; set; }
        public List<ActorStarringRole> Stars { get; set; }
        public List<CoStarringRole> CoStars { get; set; }
        public List<GuestAppearence> GuestAppearences { get; set; }
        public List<MovieComment> MovieComments { get; set; }

        [NotMapped]
        public double Rating { get; set; }
    }
}
