using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public ClubMember ClubMember { get; set; }
        public Meeting Meeting { get; set; }

    }
}
