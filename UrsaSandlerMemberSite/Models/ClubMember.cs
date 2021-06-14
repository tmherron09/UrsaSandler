using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class ClubMember: IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

        [ForeignKey("SandlerMovie")]
        public int? FavoriteSandlerMovieId { get; set; }
        public SandlerMovie FavoriteSandlerMovie { get; set; }

        [ForeignKey("SandlerMovie")]
        public int? LeastFavoriteSandlerMovieId { get; set; } 
        public SandlerMovie LeastFavoriteSandlerMovie { get; set; }



    }
}
