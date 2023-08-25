using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Notifications.Commands.DeleteNotification;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications;

namespace CoursesWebAPI.Controllers
{
    public class NotificationController:BaseController
    {
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteNotificationCommand
            {
                Id = id

            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<NotificationListVm>> GetAll(Guid userId)
        {
            var query = new GetNotificationsQuery
            {
                 UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
