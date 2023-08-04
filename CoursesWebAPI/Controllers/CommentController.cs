using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Comments.Queries.GetComments;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;

namespace CoursesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentController:BaseController
    {
        private readonly IMapper Mapper;
        public CommentController(IMapper mapper)=>Mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<CommentListVm>> GetAll(Guid CourseId)
        {
            var query = new GetCommentsQuery
            {
                CourseId = CourseId
            };
            var vm = await mediator.Send(query);
            return Ok(vm);

        }
    }
}
