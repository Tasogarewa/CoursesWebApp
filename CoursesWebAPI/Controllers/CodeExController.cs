using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.CodeExs.Commands.CreateCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Commands.DeleteCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Commands.UpdateCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Queries.GetCodeEx;

namespace CoursesWebAPI.Controllers
{
    public class CodeExController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CodeExVm>> Get(Guid codeExId)
        {
            var query = new GetCodeExQuery
            {
                 Id = codeExId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCodeExCommand createCodeExCommand)
        {
            var codeExId = await Mediator.Send(createCodeExCommand);
            return Ok(codeExId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteCodeExCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCodeExCommand updateCodeExCommand)
        {
            await Mediator.Send(updateCodeExCommand);
            return NoContent();
        }
    }
}
