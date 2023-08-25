using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserChats.Commands.CreateChat;
using Tasogarewa.Application.CQRS.UserChats.Commands.DeleteChat;
using Tasogarewa.Application.CQRS.UserChats.Commands.UpdateChat;
using Tasogarewa.Application.CQRS.UserChats.Queries.GetChat;
using Tasogarewa.Application.CQRS.UserChats.Queries.GetChats;

namespace CoursesWebAPI.Controllers
{
    public class ChatController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ChatVm>> Get(Guid chatId)
        {
            var query = new GetChatQuery
            {
                 Id = chatId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<ChatListVm>> GetAll(Guid userId)
        {
            var query = new GetChatsQuery
            {
                UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateChatCommand createChatCommand)
        {
            var chatId = await Mediator.Send(createChatCommand);
            return Ok(chatId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteChatCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateChatCommand  updateChatCommand)
        {
            await Mediator.Send(updateChatCommand);
            return NoContent();
        }
    }
}
