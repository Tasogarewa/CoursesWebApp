using Courses.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.Interfaces
{
    public interface ITasogarewaDbContext
    {
      public DbSet<Course> Courses { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
