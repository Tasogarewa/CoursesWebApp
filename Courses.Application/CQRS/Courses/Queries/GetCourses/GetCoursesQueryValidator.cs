using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourses
{
    public class GetCoursesQueryValidator:AbstractValidator<GetCoursesQuery>
    {
      public GetCoursesQueryValidator()
        {
            RuleFor(course => course.UserId).NotEqual(Guid.Empty);
        }
    }
}
