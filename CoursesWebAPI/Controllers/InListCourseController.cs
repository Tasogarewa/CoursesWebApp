using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.InListCourses.Commands.CreateInListCourses;
using Tasogarewa.Application.CQRS.InListCourses.Commands.DeleteInListCourses;

namespace CoursesWebAPI.Controllers
{
    public class InListCourseController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateInListCourseCommand createInListCourseCommand)
        {
            var inListCourseId = await Mediator.Send(createInListCourseCommand);
            return Ok(inListCourseId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteInListCourseCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
