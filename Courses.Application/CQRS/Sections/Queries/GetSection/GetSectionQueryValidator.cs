using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSection
{
    public class GetSectionQueryValidator:AbstractValidator<GetSectionQuery>
    {
        public GetSectionQueryValidator() 
        {
            RuleFor(x=>x.Id).NotEqual(x => x.Id);
        }
    }
}
