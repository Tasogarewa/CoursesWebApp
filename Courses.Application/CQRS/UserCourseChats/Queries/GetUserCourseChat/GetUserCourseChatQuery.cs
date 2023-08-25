using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat
{
    public class GetUserCourseChatQuery : IRequest<UserCourseChatVm>
    {
        public Guid Id { get; set; }
    }
}
