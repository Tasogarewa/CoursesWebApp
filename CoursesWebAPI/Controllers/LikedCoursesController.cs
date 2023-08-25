using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserLikedCourses.Queries.GetUserLikedCourses;

namespace CoursesWebAPI.Controllers
{
    public class LikedCoursesController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UserLikedCoursesVm>> Get(Guid userId)
        {
            var query = new GetUserLikedCoursesQuery
            {
                 UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
