using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.DeleteAppUser
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, Unit>
    {
        private readonly IRepository<AppUser> _userRepository;

        public DeleteAppUserCommandHandler(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if (user == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }
            else
               await _userRepository.Delete(user);
            return Unit.Value;
        }
    }
}
