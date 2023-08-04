using AutoMapper;
using CoursesWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Chats.Commands.CreateChat;
using Tasogarewa.Application.CQRS.Chats.Queries.GetChat;
using Tasogarewa.Application.CQRS.Chats.Queries.GetChats;
using Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;

namespace CoursesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChatController:BaseController
    {
        private readonly IMapper Mapper;
        public ChatController(IMapper mapper) => Mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<ChatListVm>> GetAll()
        {
            var query = new GetChatsQuery
            {
                UserId = UserId
            };

            var vm = await mediator.Send(query);
            return Ok(vm);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatVm>> Get(Guid id)
        {
            var query = new GetChatQuery
            {
                Id = id
            };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateChatDto createChatDto)
        {
            var command = Mapper.Map<CreateChatCommand>(createChatDto);
            command.Users = createChatDto.AppUsers;
            var ChatId = await mediator.Send(command);
            return Ok(ChatId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCourseCommand
            { Id = id, UserId = UserId};
            await mediator.Send(command);
            return NoContent();
        }
    }
}
