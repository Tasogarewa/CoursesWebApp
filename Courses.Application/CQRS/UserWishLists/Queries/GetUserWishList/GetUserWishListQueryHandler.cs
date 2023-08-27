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
      private readonly IUserService _userService;

        public GetUserWishListQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserWishListVm> Handle(GetUserWishListQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetWishedCoursesAsync(request);
        }
    }
}
