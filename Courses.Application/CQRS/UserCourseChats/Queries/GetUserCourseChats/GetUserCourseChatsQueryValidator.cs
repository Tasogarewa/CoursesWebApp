using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChats
{
    public class GetUserCourseChatsQueryValidator : AbstractValidator<GetUserCourseChatsQuery>
    {
        public GetUserCourseChatsQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
