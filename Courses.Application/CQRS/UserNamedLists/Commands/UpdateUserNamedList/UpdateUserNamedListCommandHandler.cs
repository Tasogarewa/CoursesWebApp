using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.UpdateUserNamedList
{
    public class UpdateUserNamedListCommandHandler : IRequestHandler<UpdateUserNamedListCommand, Guid>
    {
        private readonly INamedListService _namedListService;

        public UpdateUserNamedListCommandHandler(INamedListService namedListService)
        {
            _namedListService = namedListService;
        }

        public async Task<Guid> Handle(UpdateUserNamedListCommand request, CancellationToken cancellationToken)
        {
            return await _namedListService.UpdateNamedListAsync(request);
            
        }
    }
}
