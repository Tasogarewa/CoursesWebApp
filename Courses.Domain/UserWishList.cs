using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class UserWishList
    {
        public Guid Id { get; set; }
        public virtual ICollection<UserWishedCourse>? WishedCourses { get; set; } = new List<UserWishedCourse>();
    }
}
