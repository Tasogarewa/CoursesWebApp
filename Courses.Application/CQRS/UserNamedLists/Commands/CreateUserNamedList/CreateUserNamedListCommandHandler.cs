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
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<UserNamedList> _userNamedListRepository;

        public CreateUserNamedListCommandHandler(IRepository<AppUser> userRepository, IRepository<UserNamedList> userNamedListRepository)
        {
            _userRepository = userRepository;
            _userNamedListRepository = userNamedListRepository;
        }

        public async Task<Guid> Handle(CreateUserNamedListCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var userNamedList = await _userNamedListRepository.Create(new UserNamedList() { Name = request.Name, UserNamedCourseList = user.UserNamedCourseList });
            return userNamedList.Id;    
        }
    }
}
