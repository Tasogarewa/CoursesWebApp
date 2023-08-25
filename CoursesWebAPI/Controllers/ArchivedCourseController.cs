using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.CreateArchivedCourse;
using Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.DeleteArchivedCourse;

namespace CoursesWebAPI.Controllers
{
    public class ArchivedCourseController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateArchivedCourseCommand createArchivedCourseCommand)
        {
            var archivedCourseId = await Mediator.Send(createArchivedCourseCommand);
            return Ok(archivedCourseId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteArchivedCourseCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
