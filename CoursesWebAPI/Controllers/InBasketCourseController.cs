using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.InBasketCourses.Commands.CreateInBasketCourses;
using Tasogarewa.Application.CQRS.InBasketCourses.Commands.DeleteInBasketCourses;

namespace CoursesWebAPI.Controllers
{
    public class InBasketCourseController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateInBasketCourseCommand createInBasketCourseCommand)
        {
            var inBasketCourseId = await Mediator.Send(createInBasketCourseCommand);
            return Ok(inBasketCourseId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteInBasketCourseCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
