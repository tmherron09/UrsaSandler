// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrsaSandlerMemberSite.Data;

namespace UrsaSandlerMemberSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.ActorComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentPosterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("CommentPosterId");

                    b.ToTable("ActorComments");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.ActorStarringRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActorId")
                        .HasColumnType("int");

                    b.Property<int?>("SandlerMovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("SandlerMovieId");

                    b.ToTable("ActorStarringRoles");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClubMemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MeetingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubMemberId");

                    b.HasIndex("MeetingId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.ClubMember", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("FavoriteSandlerMovieId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeastFavoriteSandlerMovieId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("FavoriteSandlerMovieId");

                    b.HasIndex("LeastFavoriteSandlerMovieId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.CoStarringRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoStarId")
                        .HasColumnType("int");

                    b.Property<int?>("SandlerMovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoStarId");

                    b.HasIndex("SandlerMovieId");

                    b.ToTable("CoStarringRoles");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.GuestAppearence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GuestStarId")
                        .HasColumnType("int");

                    b.Property<int?>("SandlerMovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestStarId");

                    b.HasIndex("SandlerMovieId");

                    b.ToTable("GuestAppearences");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MeetingMovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeetingMovieId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.MeetingComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentPosterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MeetingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CommentPosterId");

                    b.HasIndex("MeetingId");

                    b.ToTable("MeetingComments");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.MovieComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClubMemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SandlerMovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClubMemberId");

                    b.HasIndex("SandlerMovieId");

                    b.ToTable("MovieComments");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.NewsPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClubMemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubMemberId");

                    b.ToTable("NewsPosts");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.NewsPostComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentPosterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CommentPosterId");

                    b.ToTable("NewsPostComments");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.SandlerMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHappyMadison")
                        .HasColumnType("bit");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Synonpsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SandlerMovies");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.SandlerMovieRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClubMemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("SandlerMovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubMemberId");

                    b.HasIndex("SandlerMovieId");

                    b.ToTable("SandlerMovieRatings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.ActorComment", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", "CommentPoster")
                        .WithMany()
                        .HasForeignKey("CommentPosterId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.ActorStarringRole", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "SandlerMovie")
                        .WithMany("Stars")
                        .HasForeignKey("SandlerMovieId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.Attendance", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", "ClubMember")
                        .WithMany()
                        .HasForeignKey("ClubMemberId");

                    b.HasOne("UrsaSandlerMemberSite.Models.Meeting", "Meeting")
                        .WithMany("Attenance")
                        .HasForeignKey("MeetingId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.ClubMember", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "FavoriteSandlerMovie")
                        .WithMany()
                        .HasForeignKey("FavoriteSandlerMovieId");

                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "LeastFavoriteSandlerMovie")
                        .WithMany()
                        .HasForeignKey("LeastFavoriteSandlerMovieId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.CoStarringRole", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.Actor", "CoStar")
                        .WithMany()
                        .HasForeignKey("CoStarId");

                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "SandlerMovie")
                        .WithMany("CoStars")
                        .HasForeignKey("SandlerMovieId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.GuestAppearence", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.Actor", "GuestStar")
                        .WithMany()
                        .HasForeignKey("GuestStarId");

                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "SandlerMovie")
                        .WithMany("GuestAppearences")
                        .HasForeignKey("SandlerMovieId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.Meeting", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "MeetingMovie")
                        .WithMany()
                        .HasForeignKey("MeetingMovieId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.MeetingComment", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", "CommentPoster")
                        .WithMany()
                        .HasForeignKey("CommentPosterId");

                    b.HasOne("UrsaSandlerMemberSite.Models.Meeting", "Meeting")
                        .WithMany("MeetingComments")
                        .HasForeignKey("MeetingId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.MovieComment", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", "CommentPoster")
                        .WithMany()
                        .HasForeignKey("ClubMemberId");

                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "SandlerMovie")
                        .WithMany("MovieComments")
                        .HasForeignKey("SandlerMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.NewsPost", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", "ClubMember")
                        .WithMany()
                        .HasForeignKey("ClubMemberId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.NewsPostComment", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", "CommentPoster")
                        .WithMany()
                        .HasForeignKey("CommentPosterId");
                });

            modelBuilder.Entity("UrsaSandlerMemberSite.Models.SandlerMovieRating", b =>
                {
                    b.HasOne("UrsaSandlerMemberSite.Models.ClubMember", "ClubMember")
                        .WithMany()
                        .HasForeignKey("ClubMemberId");

                    b.HasOne("UrsaSandlerMemberSite.Models.SandlerMovie", "SandlerMovie")
                        .WithMany()
                        .HasForeignKey("SandlerMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
