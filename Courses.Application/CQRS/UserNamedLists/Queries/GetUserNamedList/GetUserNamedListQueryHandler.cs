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

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedList
{
    public class GetUserNamedListQueryHandler : IRequestHandler<GetUserNamedListQuery, UserNamedListVm>
    {
        private readonly INamedListService _namedListService;

        public GetUserNamedListQueryHandler(INamedListService namedListService)
        {
            _namedListService = namedListService;
        }

        public async Task<UserNamedListVm> Handle(GetUserNamedListQuery request, CancellationToken cancellationToken)
        {
            return await _namedListService.GetNamedListAsync(request);
        }
    }
}
