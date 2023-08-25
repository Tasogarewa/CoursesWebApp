using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSections
{
    public class GetSectionsQueryValidator:AbstractValidator<GetSectionsQuery>
    {
        public GetSectionsQueryValidator() 
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
        }
    }
}
