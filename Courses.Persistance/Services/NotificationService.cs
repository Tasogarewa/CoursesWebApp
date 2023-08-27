using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Notifications.Commands.DeleteNotification;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<Notification> _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(IRepository<AppUser> userRepository, IRepository<Notification> notificationRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> DeleteNotificationAsync(DeleteNotificationCommand deleteNotification)
        {
            var notification = await _notificationRepository.GetAsync(deleteNotification.Id);
           NotFoundException<Notification>.Throw(notification, deleteNotification.Id);
            await _notificationRepository.DeleteAsync(notification);
            return Unit.Value;
        }

        public async Task<NotificationListVm> GetNotificationsAsync(GetNotificationsQuery getNotifications)
        {
            var user = await _userRepository.GetAsync(getNotifications.UserId);
            NotFoundException<AppUser>.Throw(user, getNotifications.UserId);
            return new NotificationListVm() { NotificationsList =  _mapper.ProjectTo<NotificationDto>(user.Notifications.AsQueryable()).ToList() };
        }
    }
}
