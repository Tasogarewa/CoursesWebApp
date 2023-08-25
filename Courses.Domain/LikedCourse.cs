using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class LikedCourse
    {
        public Guid Id { get; set; }
        public virtual Course Course { get; set; }
        public virtual LikedCourses LikedCourses { get; set; }
    }
}
