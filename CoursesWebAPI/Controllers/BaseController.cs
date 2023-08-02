using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoursesWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator Mediator;
        protected IMediator mediator => Mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        internal Guid UserId => !User.Identity.IsAuthenticated
                ? Guid.Empty
                : Guid.Parse(AppUser.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
