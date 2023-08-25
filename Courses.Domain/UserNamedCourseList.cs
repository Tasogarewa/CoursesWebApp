using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class UserNamedCourseList
    {
        public Guid Id { get; set; }
        public virtual ICollection<UserNamedList>? UserNamedLists { get; set; } = new List<UserNamedList>();
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
