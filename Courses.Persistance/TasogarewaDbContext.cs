using Courses.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance
{
    public class TasogarewaDbContext :DbContext,ITasogarewaDbContext
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<CourseChat> CourseChats { get; set; }
        public  virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<ArchivedCourses> ArchivedCoursesLists { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<CodeEx> CodeExes { get; set; }
        public virtual DbSet<CourseStudent> CourseStudents { get; set; }
        public virtual DbSet<CourseTag> CourseTags { get; set; }
        public virtual DbSet<Lection> Lections { get; set; }
        public virtual DbSet<LectionNotice> LectionNotices { get; set; }
        public virtual DbSet<Mentor> Mentors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<UserWishedCourse> WishedCourses { get; set; }
        public virtual DbSet<LikedCourse> LikedCourses { get; set; }
        public virtual DbSet<ArchivedCourse> ArchivedCourses { get; set; }
        public virtual DbSet<LikedCourses> LikedCoursesLists { get; set; }
        public virtual DbSet<UserWishList> UserWishLists { get; set; }
        public virtual DbSet<UserNamedCourseList> UserNamedCourseLists { get; set; }
        public virtual DbSet<UserNamedList> UserNamedLists { get; set; }
        public virtual DbSet<InListCourse> InListCourses { get; set; }
        public virtual DbSet<InBasketCourse> InBasketCourses { get; set; }
        public TasogarewaDbContext(DbContextOptions<TasogarewaDbContext> options):base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            builder.Entity<Course>()
            .HasOne(c => c.Chat)
            .WithOne(cc => cc.Course)
            .HasForeignKey<CourseChat>(cc => cc.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

          

            builder.Entity<Lection>()
       .HasOne(l => l.CodeEx)
       .WithOne(ce => ce.Lection)
       .HasForeignKey<CodeEx>(ce => ce.LectionId)
        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Lection>()
    .HasOne(l => l.Tests)
    .WithOne(ce => ce.Lection)
    .HasForeignKey<Test>(ce => ce.LectionId)
     .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppUser>()
      .HasOne(u => u.Mentor)
      .WithMany()
      .HasForeignKey(u => u.MentorId)
      .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CourseChat>()
    .HasOne(cc => cc.Mentor)
    .WithMany()
    .HasForeignKey(cc => cc.MentorId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Course>()
    .HasOne(c => c.Mentor)
    .WithMany()
    .HasForeignKey(c => c.MentorId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CourseStudent>()
        .HasKey(cs => new { cs.CourseId, cs.UserId });

            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.User)
                .WithMany(s => s.Courses)
                .HasForeignKey(cs => cs.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Announcement>()
       .HasOne(a => a.Course)
       .WithMany(c => c.Announcements)
       .HasForeignKey(a => a.CourseId)
      .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
