using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.DeleteUserNamedList
{
    public class DeleteUserNamedListCommandHandler : IRequestHandler<DeleteUserNamedListCommand, Unit>
    {
        private readonly INamedListService _namedListService;

        public DeleteUserNamedListCommandHandler(INamedListService namedListService)
        {
            _namedListService = namedListService;
        }

        public async Task<Unit> Handle(DeleteUserNamedListCommand request, CancellationToken cancellationToken)
        {
            return await _namedListService.DeleteNamedListAsync(request);
        }
    }
}
