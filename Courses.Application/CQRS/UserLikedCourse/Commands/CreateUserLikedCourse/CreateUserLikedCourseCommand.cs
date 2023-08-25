using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserLikedCourse.Commands.CreateUserLikedCourse
{
    public class CreateUserLikedCourseCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
    }
}
