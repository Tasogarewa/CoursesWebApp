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
        public  virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public TasogarewaDbContext(DbContextOptions<TasogarewaDbContext> options):base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Comment>()
        .HasOne(c => c.Course)
        .WithMany()
        .HasForeignKey(c => c.Id)
        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Image>()
       .HasOne(i => i.Course)
       .WithMany()
       .HasForeignKey(i => i.Id)
       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
