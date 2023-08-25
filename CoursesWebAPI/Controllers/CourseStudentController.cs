using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.CourseStudents.Commands.CreateCourseStudents;

namespace CoursesWebAPI.Controllers
{
    public class CourseStudentController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseStudentCommand  createCourseStudentCommand)
        {
            var courseStudentId = await Mediator.Send(createCourseStudentCommand);
            return Ok(courseStudentId);
        }
    }
}
