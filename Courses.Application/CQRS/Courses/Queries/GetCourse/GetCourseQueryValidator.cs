using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourse
{
    public class GetCourseQueryValidator:AbstractValidator<GetCourseQuery>
    {
        public GetCourseQueryValidator() 
        {
            RuleFor(course => course.Id).NotEqual(Guid.Empty);
        }
    }
}
