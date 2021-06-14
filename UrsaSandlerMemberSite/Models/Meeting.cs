using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime MeetingDate { get; set; }
        public SandlerMovie MeetingMovie { get; set; }
        public List<Attendance> Attenance { get; set; }



    }
}
