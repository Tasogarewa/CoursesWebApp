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
        private readonly IRepository<UserNamedList> _userNamedListRepository;

        public UpdateUserNamedListCommandHandler(IRepository<UserNamedList> userNamedListRepository)
        {
            _userNamedListRepository = userNamedListRepository;
        }

        public async Task<Guid> Handle(UpdateUserNamedListCommand request, CancellationToken cancellationToken)
        {
            var userNamedList = await _userNamedListRepository.GetAsync(request.Id);
            if (userNamedList == null||request.Id==Guid.Empty) 
            {
                throw new NotFoundException(nameof(userNamedList),request.Id);
            }
            else
            {
                userNamedList.Name=request.Name;
              await  _userNamedListRepository.Update(userNamedList);
                return userNamedList.Id;
            }
            
        }
    }
}
