using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket
{
    public class GetBasketQueryValidator:AbstractValidator<GetBasketQuery>
    {
        public GetBasketQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
