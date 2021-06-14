using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UrsaSandlerMemberSite.Models;

namespace UrsaSandlerMemberSite.ViewModels
{
    public class AssignActorViewModel
    {
        [Required]
        public int SandlerMovieId;
        public SandlerMovie SandlerMovie;
        [Required]
        public int ActorId;
        public Actor Actor;
        [Required]
        public AssignType AssignmentType;



        public enum AssignType
        {
            StarringRole,
            CoStarringRole,
            GuestAppearence
        }
    }
}
