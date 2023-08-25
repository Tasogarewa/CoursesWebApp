using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class LikedCourses
    {
        public Guid Id { get; set; }
        public virtual ICollection<LikedCourse>? Courses { get; set; } = new List<LikedCourse>();
    }
}
