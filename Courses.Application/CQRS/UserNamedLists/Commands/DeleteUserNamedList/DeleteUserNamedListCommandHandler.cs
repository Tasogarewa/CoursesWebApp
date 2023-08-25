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
        private readonly IRepository<UserNamedList> _userNamedListRepository;

        public DeleteUserNamedListCommandHandler(IRepository<UserNamedList> userNamedListRepository)
        {
            _userNamedListRepository = userNamedListRepository;
        }

        public async Task<Unit> Handle(DeleteUserNamedListCommand request, CancellationToken cancellationToken)
        {
            var userNamedList = await _userNamedListRepository.GetAsync(request.Id);
            if(userNamedList==null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(userNamedList), request.Id);
            }
            else
              await  _userNamedListRepository.Delete(userNamedList);
            return Unit.Value;
        }
    }
}
