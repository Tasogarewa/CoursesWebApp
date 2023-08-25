using Microsoft.AspNetCore.Mvc;

using Tasogarewa.Application.CQRS.Mentors.Commands.UpdateMentor;
using Tasogarewa.Application.CQRS.Mentors.Queries.GetMentor;
using Tasogarewa.Application.CQRS.Mentors.Queries.GetMentors;

namespace CoursesWebAPI.Controllers
{
    public class MentorController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MentorVm>> Get(Guid mentorId)
        {
            var query = new GetMentorQuery
            {
                 Id = mentorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<MentorListVm>> GetAll()
        {
            var query = new GetMentorsQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateMentorCommand  updateMentorCommand)
        {
            await Mediator.Send(updateMentorCommand);
            return NoContent();
        }
    }
}
