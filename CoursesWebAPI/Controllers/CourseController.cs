using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;



namespace CoursesWebAPI.Controllers
{
    public class CourseController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CourseVm>> Get(Guid courseId)
        {
            var query = new GetCourseQuery
            {
                Id = courseId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<CourseListVm>> GetAllCMentorCourse(Guid mentorId)
        {
            var query = new GetMentorCoursesQuery
            {
                MentorId = mentorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<CourseListVm>> GetAll()
        {
            var query = new GetCoursesQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseCommand createCourseCommand)
        {
            var courseId = await Mediator.Send(createCourseCommand);
            return Ok(courseId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteCourseCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCourseCommand  updateCourseCommand)
        {
            await Mediator.Send(updateCourseCommand);
            return NoContent();
        }
    }
}
