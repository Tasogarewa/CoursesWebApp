using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Lections.Commands.CreateLection;
using Tasogarewa.Application.CQRS.Lections.Commands.DeleteLection;
using Tasogarewa.Application.CQRS.Lections.Commands.UpdateLection;
using Tasogarewa.Application.CQRS.Lections.Queries.GetLection;

namespace CoursesWebAPI.Controllers
{
    public class LectionController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<LectionVm>> Get(Guid lectionId)
        {
            var query = new GetLectionQuery
            {
                Id = lectionId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateLectionCommand createLectionCommand)
        {
            var lectionId = await Mediator.Send(createLectionCommand);
            return Ok(lectionId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteLectionCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateLectionCommand updateLectionCommand)
        {
            await Mediator.Send(updateLectionCommand);
            return NoContent();
        }
    }
}
