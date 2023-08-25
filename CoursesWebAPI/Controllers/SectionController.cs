using MediatR;
using Microsoft.AspNetCore.Mvc;

using Tasogarewa.Application.CQRS.Sections.Commands.CreateSection;
using Tasogarewa.Application.CQRS.Sections.Commands.DeleteSection;
using Tasogarewa.Application.CQRS.Sections.Commands.UpdateSection;
using Tasogarewa.Application.CQRS.Sections.Queries.GetSection;
using Tasogarewa.Application.CQRS.Sections.Queries.GetSections;

namespace CoursesWebAPI.Controllers
{
    public class SectionController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<SectionListVm>> GetAll(Guid courseId)
        {
            var query = new GetSectionsQuery
            {
                CourseId = courseId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<SectionVm>> Get(Guid secionId)
        {
            var query = new GetSectionQuery
            {
                Id  = secionId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSectionCommand createSectionCommand)
        {
            var sectionId = await Mediator.Send(createSectionCommand);
            return Ok(sectionId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteSectionCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateSectionCommand updateSectionCommand)
        {
            await Mediator.Send(updateSectionCommand);
            return NoContent();
        }
    }
}
