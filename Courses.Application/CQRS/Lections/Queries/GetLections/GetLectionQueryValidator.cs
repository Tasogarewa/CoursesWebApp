using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLections
{
    public class GetLectionQueryValidator:AbstractValidator<GetLectionsQuery>
    {
        public GetLectionQueryValidator() 
        {
            RuleFor(x=>x.SectionId).NotEqual(Guid.Empty);
        }
    }
}
