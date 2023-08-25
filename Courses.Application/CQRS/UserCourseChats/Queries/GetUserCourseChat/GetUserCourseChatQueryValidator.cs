using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat
{
    public class GetUserCourseChatQueryValidator : AbstractValidator<GetUserCourseChatQuery>
    {
        public GetUserCourseChatQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
