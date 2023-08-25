using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.DeleteWishedCourse
{
    public class DeleteWishedCourseCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
