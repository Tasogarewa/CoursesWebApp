
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket;

namespace CoursesWebAPI.Controllers
{
    public class BasketController:BaseController
    {
       
        [HttpGet]
        public async Task<ActionResult<BasketVm>> Get(Guid userId)
        {
            var query = new GetBasketQuery
            {
                UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
