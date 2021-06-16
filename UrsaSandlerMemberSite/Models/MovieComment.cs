using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class MovieComment : IComment
    {
        public int Id { get; set; }

        [ForeignKey("SandlerMovie")]
        public int SandlerMovieId { get; set; }
        public SandlerMovie SandlerMovie { get; set; }
        public string ClubMemberId { get; set; }
        [ForeignKey("ClubMemberId")]
        public ClubMember CommentPoster { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
        [NotMapped]
        public string DateFormatted => TimeStamp.ToString("MMM dd, yyyy");
    }
}
