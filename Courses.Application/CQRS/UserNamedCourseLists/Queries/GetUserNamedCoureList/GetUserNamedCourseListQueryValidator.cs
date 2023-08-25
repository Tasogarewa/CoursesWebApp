using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedCourseLists.Queries.GetUserNamedCoureList
{
    public class GetUserNamedCourseListQueryValidator:AbstractValidator<GetUserNamedCourseListQuery>
    {
        public GetUserNamedCourseListQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
