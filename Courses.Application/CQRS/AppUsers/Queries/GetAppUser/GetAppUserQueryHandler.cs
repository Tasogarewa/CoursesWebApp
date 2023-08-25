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

namespace Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, AppUserVm>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetAppUserQueryHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AppUserVm> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id);
            if (user == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }
            else
                return _mapper.Map<AppUserVm>(user);    
        }
    }
}
