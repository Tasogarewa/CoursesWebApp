using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourse
{
    public class GetCourseQuery:IRequest<CourseVm>
    {
        public Guid Id { get; set; }
    }
}
