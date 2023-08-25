using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Domain
{
    public class ArchivedCourses
    {
        public Guid Id { get; set; }
public virtual ICollection<ArchivedCourse>? Courses { get; set; } = new List<ArchivedCourse>();

    }
}
