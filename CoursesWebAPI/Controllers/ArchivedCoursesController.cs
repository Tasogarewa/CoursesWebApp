
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserArchivedCourses.Queries.GetArchivedCourses;

namespace CoursesWebAPI.Controllers
{
    public class ArchivedCoursesController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ArchivedCourseVm>> Get(Guid userId)
        {
            var query = new GetArchivedCoursesQuery
            {
                UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
