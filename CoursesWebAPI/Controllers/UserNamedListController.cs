using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.CreateUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.DeleteUserNamedList;

namespace CoursesWebAPI.Controllers
{
    public class UserNamedListController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserNamedListCommand createUserNamedListCommand)
        {
            var userNamedListId = await Mediator.Send(createUserNamedListCommand);
            return Ok(userNamedListId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteUserNamedListCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
