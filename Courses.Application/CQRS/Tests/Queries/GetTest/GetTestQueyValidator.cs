using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Tests.Queries.GetTest
{
    public class GetTestQueyValidator:AbstractValidator<GetTestQuery>
    {
        public GetTestQueyValidator() 
        {
            RuleFor(x => x.Id);
        }
    }
}
