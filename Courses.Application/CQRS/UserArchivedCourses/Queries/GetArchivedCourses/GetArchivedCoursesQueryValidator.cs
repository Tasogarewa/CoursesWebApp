using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserArchivedCourses.Queries.GetArchivedCourses
{
    public class GetArchivedCoursesQueryValidator:AbstractValidator<GetArchivedCoursesQuery>
    {
        public GetArchivedCoursesQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
