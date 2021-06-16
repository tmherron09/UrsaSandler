using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }
        public SandlerMovie MeetingMovie { get; set; }
        public List<Attendance> Attenance { get; set; }
        public List<MeetingComment> MeetingComments { get; set; }
        [NotMapped]
        public string DateFormatted => MeetingDate.ToString("MMM dd, yyyy");

    }
}
