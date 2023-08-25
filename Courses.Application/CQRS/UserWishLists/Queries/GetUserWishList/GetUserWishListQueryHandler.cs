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

namespace Tasogarewa.Application.CQRS.UserWishLists.Queries.GetUserWishList
{
    public class GetUserWishListQueryHandler : IRequestHandler<GetUserWishListQuery, UserWishListVm>
    {
      
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetUserWishListQueryHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserWishListVm> Handle(GetUserWishListQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null||request.UserId==Guid.Empty) 
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }
            else
                return _mapper.Map<UserWishListVm>(user);
        }
    }
}
