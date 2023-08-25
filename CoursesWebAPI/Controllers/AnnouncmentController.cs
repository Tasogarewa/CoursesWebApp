using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Announcments.Commands.CreateAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Commands.DeleteAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Commands.UpdateAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments;

namespace CoursesWebAPI.Controllers
{
    public class AnnouncmentController:BaseController
    { 
       

        [HttpGet]
        public async Task<ActionResult<AnnouncmentListVm>> GetAll(Guid courseId)
        {
            var query = new GetAnnouncmentsQuery
            {
                CourseId = courseId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAnnouncmentCommand createAnnouncmentCommand)
        {
            var announcmentId = await Mediator.Send(createAnnouncmentCommand);
            return Ok(announcmentId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteAnnouncmentCommand
            {
                Id = id,
                UserId = UserId

            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateAnnouncmentCommand updateAnnouncmentCommand)
        {
            await Mediator.Send(updateAnnouncmentCommand);
            return NoContent();
        }
    }
}
