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
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetBasketQueryHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BasketVm> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null || request.UserId == Guid.Empty)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }
            else
                return  _mapper.Map<BasketVm>(user.Basket);
        }
    }
}
