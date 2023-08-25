using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.InListCourses.Commands.CreateInListCourses
{
    public class CreateInListCourseCommand:IRequest<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid UserNamedListId { get; set; }
    }
}
