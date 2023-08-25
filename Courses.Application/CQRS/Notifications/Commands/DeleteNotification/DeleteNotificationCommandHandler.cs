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
        private readonly IRepository<Notification> _notificationsRepository;

        public DeleteNotificationCommandHandler(IRepository<Notification> notificationsRepository)
        {
            _notificationsRepository = notificationsRepository;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _notificationsRepository.GetAsync(request.Id);
            if (notification == null || notification.Id != request.Id||request.UserId!=Guid.Empty)
            {
                throw new NotFoundException(nameof(Notification), request.Id);
            }
            else
               await _notificationsRepository.Delete(notification);
            return Unit.Value;
        }
    }
}
