using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.CreateLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.DeleteLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.UpdateLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices;

namespace CoursesWebAPI.Controllers
{
    public class LectionNoticeController:BaseController
    {

        [HttpGet]
        public async Task<ActionResult<LectionNoticeListVm>> GetAll(Guid lectionId)
        {
            var query = new GetLectionNoticesQuery
            {
                LectionId = lectionId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateLectionNoticeCommand createLectionNoticeCommand)
        {
            var lectionNoticeId = await Mediator.Send(createLectionNoticeCommand);
            return Ok(lectionNoticeId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteLectionNoticeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateLectionNoticeCommand  updateLectionNoticeCommand)
        {
            await Mediator.Send(updateLectionNoticeCommand);
            return NoContent();
        }
    }
}
