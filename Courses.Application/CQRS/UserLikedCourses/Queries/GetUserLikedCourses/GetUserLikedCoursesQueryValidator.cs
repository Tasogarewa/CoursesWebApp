using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserLikedCourses.Queries.GetUserLikedCourses
{
    public class GetUserLikedCoursesQueryValidator:AbstractValidator<GetUserLikedCoursesQuery>
    {
        public GetUserLikedCoursesQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
