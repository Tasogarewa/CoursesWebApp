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

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedList
{
    public class GetUserNamedListQueryHandler : IRequestHandler<GetUserNamedListQuery, UserNamedListVm>
    {
        private readonly IRepository<UserNamedList> _userNamedListRepository;
        private readonly IMapper _mapper;

        public GetUserNamedListQueryHandler(IRepository<UserNamedList> userNamedListRepository, IMapper mapper)
        {
            _userNamedListRepository = userNamedListRepository;
            _mapper = mapper;
        }

        public async Task<UserNamedListVm> Handle(GetUserNamedListQuery request, CancellationToken cancellationToken)
        {
            var userNamedList = _userNamedListRepository.GetAsync(request.Id);
            if (userNamedList == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(userNamedList), request.Id);
            }
            else
                return _mapper.Map<UserNamedListVm>(userNamedList);
        }
    }
}
