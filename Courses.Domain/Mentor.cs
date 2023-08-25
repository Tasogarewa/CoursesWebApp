using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class Mentor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public virtual Image? Image { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<CourseChat>? CourseChats { get; set; } = new List<CourseChat>();
        public virtual ICollection<Notification>? Notifications { get; set; } = new List<Notification>();
        public virtual ICollection<CourseStudent>? Students { get; set; } = new List<CourseStudent>();
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
        public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Web { get; set; }
        public string? YouTube { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? GitHub { get; set; }
    }
}
