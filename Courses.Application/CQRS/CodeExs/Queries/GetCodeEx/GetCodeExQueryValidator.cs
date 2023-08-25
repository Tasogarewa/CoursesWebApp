using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CodeExs.Queries.GetCodeEx
{
    public class GetCodeExQueryValidator:AbstractValidator<GetCodeExQuery>
    {
        public GetCodeExQueryValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
