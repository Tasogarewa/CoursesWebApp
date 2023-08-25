using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class UserNamedList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual UserNamedCourseList UserNamedCourseList { get; set; }
        public virtual ICollection<InListCourse> InListCourses { get; set; }
    }
}
