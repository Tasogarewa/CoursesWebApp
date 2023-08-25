using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.AppUsers.Commands.CreateAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Commands.DeleteAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Commands.UpdateAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser;

namespace CoursesWebAPI.Controllers
{
    public class UserController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<AppUserVm>> Get(Guid userId)
        {
            var query = new GetAppUserQuery()
            {
                Id = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAppUserCommand createAppUserCommand)
        {
            var userId = await Mediator.Send(createAppUserCommand);
            return Ok(userId);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAppUserCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserCommand  updateAppUserCommand)
        {
            await Mediator.Send(updateAppUserCommand);
            return NoContent();
        }
    }
}
