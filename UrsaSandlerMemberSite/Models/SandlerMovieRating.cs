using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class SandlerMovieRating
    {
        public int Id { get; set; }
        [ForeignKey("SandlerMovie")]
        public int SandlerMovieId { get; set; }
        public SandlerMovie SandlerMovie { get; set; }
        [ForeignKey("ClubMember")]
        public string ClubMemberId { get; set; }
        public ClubMember ClubMember { get; set; }

        [Required]
        [Range(minimum:0, maximum: 26)]
        public double Rating { get; set; }

    }
}
