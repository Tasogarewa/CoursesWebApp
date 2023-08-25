using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedCourseLists.Queries.GetUserNamedCoureList
{
    public class GetUserNamedCourseListQuery:IRequest<UserNamedCourseListVm>
    {
        public Guid UserId { get; set; }
    }
}
