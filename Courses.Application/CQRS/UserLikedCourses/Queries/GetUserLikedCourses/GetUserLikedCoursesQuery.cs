using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserLikedCourses.Queries.GetUserLikedCourses
{
    public class GetUserLikedCoursesQuery:IRequest<UserLikedCoursesVm>
    {
        public Guid UserId { get; set; }
    }
}
