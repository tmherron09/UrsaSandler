using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UrsaSandlerMemberSite.Models;

namespace UrsaSandlerMemberSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ClubMember>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SandlerMovie> SandlerMovies { get; set; }
        public DbSet<SandlerMovieRating> SandlerMovieRatings { get; set; }
        public DbSet<MovieComment> MovieComments { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorStarringRole> ActorStarringRoles{ get; set; }
        public DbSet<CoStarringRole> CoStarringRoles { get; set; }
        public DbSet<GuestAppearence> GuestAppearences { get; set; }
        public DbSet<ActorComment> ActorComments { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<MeetingComment> MeetingComments { get; set; }


    }
}
