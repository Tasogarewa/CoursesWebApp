using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChats
{
    public class GetMentorCourseChatsQueryValidator:AbstractValidator<GetMentorCourseChatsQuery>
    {
        public GetMentorCourseChatsQueryValidator()
        {
            RuleFor(x => x.MentorId).NotEqual(Guid.Empty);
        }
    }
}
