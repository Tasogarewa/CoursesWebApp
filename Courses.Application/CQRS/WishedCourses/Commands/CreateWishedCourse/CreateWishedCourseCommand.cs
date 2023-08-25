using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.CreateWishedCourse
{
    public class CreateWishedCourseCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
