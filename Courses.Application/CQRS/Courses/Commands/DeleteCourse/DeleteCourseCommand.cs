using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
