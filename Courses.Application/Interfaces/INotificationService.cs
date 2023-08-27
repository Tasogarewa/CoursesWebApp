
using MediatR;
using Tasogarewa.Application.CQRS.Notifications.Commands.DeleteNotification;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications;

namespace Tasogarewa.Application.Interfaces
{
    public interface INotificationService
    {
        public Task<NotificationListVm> GetNotificationsAsync(GetNotificationsQuery getNotifications);
        public Task<Unit> DeleteNotificationAsync(DeleteNotificationCommand deleteNotification);
    }
}
