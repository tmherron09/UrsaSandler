using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;

namespace UrsaSandlerMemberSite.ViewModels
{
    public class HomeViewModel
    {
        public Meeting ThisWeekMeeting { get; set; }
        public List<NewsPost> NewsPosts { get; set; }

    }
}
