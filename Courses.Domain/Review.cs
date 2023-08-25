using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public virtual AppUser User { get; set; }
        public int RatingOfReview { get; set; }
        public int Rating { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public virtual ICollection<Image>? Images { get; set; } = new List<Image>();
        public string Text { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();

    }
}
