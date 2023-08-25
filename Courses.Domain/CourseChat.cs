using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class CourseChat
    {
        public Guid Id { get; set; }
        public Guid MentorId { get; set; }
        public virtual Mentor Mentor { get; set; }
        public string Name { get; set; }    
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<AppUser>? Users { get; set; }
        public virtual ICollection<Message>? Messages { get; set; } = new List<Message>();
        public virtual ICollection<Image>? Images { get; set; } = new List<Image>();
    }
}
