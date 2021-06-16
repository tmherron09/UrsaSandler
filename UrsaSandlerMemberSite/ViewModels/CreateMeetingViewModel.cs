using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;

namespace UrsaSandlerMemberSite.ViewModels
{
    public class CreateMeetingViewModel
    {
        public List<SandlerMovie> SandlerMovies { get; set; }
        public DateTime MeetingDate { get; set; }
        public int SandlerMovieId { get; set; }
    }
}
