using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.UserWishLists.Queries.GetUserWishList;

namespace CoursesWebAPI.Controllers
{
    public class UserWishListController:BaseController
    {

        [HttpGet]
        public async Task<ActionResult<UserWishListVm>> Get(Guid userId)
        {
            var query = new GetUserWishListQuery
            {
                UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
