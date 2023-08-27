using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public Guid MentorId { get; set; }
        public virtual Mentor Mentor { get; set; }
        public string Text { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
