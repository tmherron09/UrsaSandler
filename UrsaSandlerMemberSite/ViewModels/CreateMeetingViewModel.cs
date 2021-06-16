using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;
using UrsaSandlerMemberSite.Services;

namespace UrsaSandlerMemberSite.ViewModels
{
    public class CreateMeetingViewModel
    {
        public List<SandlerMovie> SandlerMovies { get; set; }
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }
        public int SandlerMovieId { get; set; }

        public CreateMeetingViewModel()
        {

        }

        public CreateMeetingViewModel(DataService dataService)
        {
            SandlerMovies = dataService.GetAllSandlerMovies();
        }
    }
}
