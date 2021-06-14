using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrsaSandlerMemberSite.Models
{
    public class ActorStarringRole
    {
        public int Id { get; set; }
        public SandlerMovie SandlerMovie { get; set; }
        public Actor Actor { get; set; }


    }
}
