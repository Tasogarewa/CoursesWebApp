using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.CreateArchivedCourse
{
    public class CreateArchivedCourseCommandValidator:AbstractValidator<CreateArchivedCourseCommand>
    {
        public CreateArchivedCourseCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x=>x.CourseId).NotEqual(Guid.Empty);
        }
    }
}
