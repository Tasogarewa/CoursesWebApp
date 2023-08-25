using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserNamedCourseLists.Queries.GetUserNamedCoureList;
using Tasogarewa.Domain;

namespace CoursesWebAPI.Controllers
{
    public class UserNamedCourseListController:BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UserNamedCourseListVm>> Get(Guid userId)
        {
            var query = new GetUserNamedCourseListQuery
            {
                UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
