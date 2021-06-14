using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}";}
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public int NumberOfFilms { get; set; }
    }
}


// Notes: on ViewModel- Number of films with Sandler