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

namespace Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, AppUserVm>
    {
        private readonly IUserService _userService;

        public GetAppUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AppUserVm> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserAsync(request);
        }
    }
}
