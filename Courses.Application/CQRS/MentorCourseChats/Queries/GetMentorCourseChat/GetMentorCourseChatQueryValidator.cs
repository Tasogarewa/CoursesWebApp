using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChat
{
    public class GetMentorCourseChatQueryValidator:AbstractValidator<GetMentorCourseChatQuery>
    {
        public GetMentorCourseChatQueryValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
