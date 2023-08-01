using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, Unit>
    {
        private readonly IRepository<Notification> NotificationsRepository;


        public DeleteNotificationCommandHandler(Repository<Notification> repository)
        {
            NotificationsRepository = repository;

        }
        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var Notification = await NotificationsRepository.GetAsync(request.Id);
            if (Notification == null || Notification.Id != request.Id)
            {
                throw new NotFoundException(nameof(Notification), request.Id);
            }
            else
                NotificationsRepository.Delete(Notification);
            return Unit.Value;
        }
    }
}
