using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Messages.Queries.GetMessages;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications;

namespace CoursesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : BaseController
    {

        private readonly IMapper Mapper;
        public MessageController(IMapper mapper) => Mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<MessagesListVm>> GetAll(Guid id)
        {
            var query = new GetMessagesQuery
            {
           ChatId =  id
            };

            var vm = await mediator.Send(query);
            return Ok(vm);

        }

    }
}
