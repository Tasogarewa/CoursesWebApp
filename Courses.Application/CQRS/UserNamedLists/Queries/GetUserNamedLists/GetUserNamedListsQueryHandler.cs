using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedLists
{
    public class GetUserNamedListsQueryHandler : IRequestHandler<GetUserNamedListsQuery, UserNamedListDtoVm>
    {
        private readonly INamedListService _namedListService;

        public Task<UserNamedListDtoVm> Handle(GetUserNamedListsQuery request, CancellationToken cancellationToken)
        {
            return _namedListService.GetNamedListsAsync(request);
        }
    }
}
