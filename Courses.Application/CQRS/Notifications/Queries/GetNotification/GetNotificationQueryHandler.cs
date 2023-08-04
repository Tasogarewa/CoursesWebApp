using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Images.Queries.GetImage;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotification
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, NotificationVm>
    {
        private readonly IMapper Mapper;
        private readonly IRepository<Notification> NotificationsRepository;
        public GetNotificationQueryHandler(Repository<Notification> repository, IMapper mapper)
        {
            NotificationsRepository = repository;
            Mapper = mapper;
        }

        public async Task<NotificationVm> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var Notification = await NotificationsRepository.GetAsync(request.Id);
            if (Notification == null||request.UserId==null)
            {
                throw new NotFoundException(nameof(Notification), request.Id);
            }
            else
                return Mapper.Map<NotificationVm>(Notification);
        }
    }
 }

