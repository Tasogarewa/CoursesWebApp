using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.UpdateCourseChat
{
    public class UpdateCourseChatCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
