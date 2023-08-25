using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourses
{
    public class GetMentorCoursesQuery:IRequest<CourseListVm>
    {
        public Guid MentorId { get; set; }
    }
}
