using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class NewsPostComment : IComment
    {
        public int Id { get; set; }
        public ClubMember CommentPoster { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
