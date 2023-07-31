using Courses.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Persistance
{
    public class TasogarewaDbContext :DbContext,ITasogarewaDbContext
    {
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
            
        }
    }
}
