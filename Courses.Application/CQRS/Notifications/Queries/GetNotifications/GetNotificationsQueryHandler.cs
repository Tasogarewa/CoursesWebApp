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
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotification;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, NotificationListVm>
    {
        private readonly IMapper Mapper;
        private readonly IRepository<Notification> NotificationsRepository;
        public GetNotificationsQueryHandler(IRepository<Notification> repository, IMapper mapper)
        {
            NotificationsRepository = repository;
            Mapper = mapper;
        }

        public async Task<NotificationListVm> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var Notifications = await NotificationsRepository.GetAllAsync();
            if (Notifications == null)
            {
                throw new NotFoundException(nameof(Notifications), request.UserId);
            }
            else
                return new NotificationListVm() { NotificationsList = await Mapper.ProjectTo<NotificationDto>((IQueryable)Notifications.Where(x => x.appUser.Id == request.UserId)).ToListAsync() };
        }
    }
}
