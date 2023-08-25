using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.DeleteCourseChat
{
    public class DeleteCourseChatCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
