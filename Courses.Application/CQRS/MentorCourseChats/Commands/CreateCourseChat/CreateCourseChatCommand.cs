using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat
{
    public class CreateCourseChatCommand:IRequest<Guid>
    {
        public Guid MentorId { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
    }
}
