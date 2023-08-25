using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments
{
    public class GetAnnouncmentsQueryValidator:AbstractValidator<GetAnnouncmentsQuery>
    {
        public GetAnnouncmentsQueryValidator() 
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
        }
    }
}
