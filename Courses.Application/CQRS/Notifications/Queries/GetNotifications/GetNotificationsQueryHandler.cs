using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, NotificationListVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppUser> _userRepository;

        public GetNotificationsQueryHandler(IMapper mapper, IRepository<AppUser> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<NotificationListVm> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }
            else
                return new NotificationListVm() { NotificationsList = await _mapper.ProjectTo<NotificationDto>((IQueryable)user.Notifications).ToListAsync() };
        }
    }
}
