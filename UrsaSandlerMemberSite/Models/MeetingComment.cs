using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class MeetingComment: IComment
    {

        public int Id { get; set; }
        public Meeting Meeting { get; set; }
        public ClubMember CommentPoster { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
        public string Comment { get; set; }

    }
}
