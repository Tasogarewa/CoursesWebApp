using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserLikedCourse.Commands.CreateUserLikedCourse;
using Tasogarewa.Application.CQRS.UserLikedCourse.Commands.DeleteUserLikedCourse;

namespace CoursesWebAPI.Controllers
{
    public class LikedCourseController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserLikedCourseCommand  createUserLikedCourseCommand)
        {
            var likedCourseId = await Mediator.Send(createUserLikedCourseCommand);
            return Ok(likedCourseId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteUserLikedCourseCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
