using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.WishedCourses.Commands.CreateWishedCourse;
using Tasogarewa.Application.CQRS.WishedCourses.Commands.DeleteWishedCourse;

namespace CoursesWebAPI.Controllers
{
    public class WishedCourseController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateWishedCourseCommand createWishedCourseCommand)
        {
            var wishedCourseId = await Mediator.Send(createWishedCourseCommand);
            return Ok(wishedCourseId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteWishedCourseCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
