using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChats
{
    public class GetMentorCourseChatsQuery:IRequest<MentorCourseChatListVm>
    {
        public Guid MentorId { get; set; }
    }
}
