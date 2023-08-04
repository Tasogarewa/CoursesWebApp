using AutoMapper;
using CoursesWebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Chats.Commands.CreateChat;
using Tasogarewa.Application.CQRS.Chats.Queries.GetChat;
using Tasogarewa.Application.CQRS.Chats.Queries.GetChats;
using Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;
using Tasogarewa.Application.CQRS.Notifications.Commands.DeleteNotification;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotification;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications;

namespace CoursesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController:BaseController
    {
        private readonly IMapper Mapper;
        public NotificationController(IMapper mapper) => Mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<NotificationListVm>> GetAll()
        {
            var query = new GetNotificationsQuery
            {
                UserId = UserId
            };

            var vm = await mediator.Send(query);
            return Ok(vm);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationVm>> Get(Guid id)
        {
            var query = new GetNotificationQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }
       
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteNotificationCommand
            { Id = id, UserId = UserId };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
