using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserLikedCourse.Commands.DeleteUserLikedCourse
{
    public class DeleteUserLikedCourseCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
