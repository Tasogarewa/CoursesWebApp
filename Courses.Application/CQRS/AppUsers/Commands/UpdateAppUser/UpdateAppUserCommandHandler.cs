using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, Guid>
    {
        private readonly IRepository<AppUser> _userRepository;

        public UpdateAppUserCommandHandler(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if (user == null||request.Id==Guid.Empty) 
            {
                throw new NotFoundException(nameof(user),request.Id);
            }
            else
            {
                user.Surname=request.Surname;
                user.Name=request.Name;
                user.Email=request.Email;
                user.Image = request.Image;
                _userRepository.Update(user);
                return user.Id;
            }
        }
    }
}
