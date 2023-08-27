using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketVm>
    {
      private readonly IUserService _userService;

        public GetBasketQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BasketVm> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetBasketAsync(request);
        }
    }
}
