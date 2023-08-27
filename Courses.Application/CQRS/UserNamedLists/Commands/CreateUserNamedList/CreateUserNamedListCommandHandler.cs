using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.CreateUserNamedList
{
    public class CreateUserNamedListCommandHandler : IRequestHandler<CreateUserNamedListCommand, Guid>
    {
      private readonly INamedListService _namedListService;

        public CreateUserNamedListCommandHandler(INamedListService namedListService)
        {
            _namedListService = namedListService;
        }

        public async Task<Guid> Handle(CreateUserNamedListCommand request, CancellationToken cancellationToken)
        {
            return await _namedListService.CreateNamedListAsync(request);

        }
    }
}
