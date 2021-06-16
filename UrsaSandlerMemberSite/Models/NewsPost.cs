using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class NewsPost
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string BodyText { get; set; }
        public string ImageUrl { get; set; }
        public ClubMember ClubMember { get; set; }
        public DateTime Timestamp { get; set; }

        [NotMapped]
        public string DateFormatted => Timestamp.ToString("MMM dd, yyyy");


    }
}
