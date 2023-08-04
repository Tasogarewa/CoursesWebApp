
using AutoMapper;
using CoursesWebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;

namespace CoursesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : BaseController
    {
        private readonly IMapper Mapper;
        public CourseController(IMapper mapper)=>Mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<ChatListVm>> GetAll()
        {
            var query = new GetCoursesQuery
            {
                 UserId = UserId
            };

            var vm = await mediator.Send(query);
            return Ok(vm);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseVm>> Get(Guid id)
        {
            var query = new GetCourseQuery
            {
                Id = id
            };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseDto createCourseDto)
        {
            var command = Mapper.Map<CreateCourseCommand>(createCourseDto);
            command.UserId = UserId;
            var CourseId = await mediator.Send(command);
            return Ok(CourseId);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCourseDto updateCourseDto)
        {
            var command = Mapper.Map<UpdateCourseCommand>(updateCourseDto);
            command.UserId = UserId;
            await mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCourseCommand
            { Id = id ,UserId = UserId };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
