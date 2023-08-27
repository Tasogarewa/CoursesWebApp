using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLection
{
    public class GetLectionQueryValidator:AbstractValidator<GetLectionQuery>
    {
        public GetLectionQueryValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
