using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket
{
    public class GetBasketQuery:IRequest<BasketVm>
    {
        public Guid UserId { get; set; }
    }
}
