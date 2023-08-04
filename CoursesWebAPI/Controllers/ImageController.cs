using AutoMapper;
using CoursesWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;
using Tasogarewa.Application.CQRS.Images.Commands.CreateImage;
using Tasogarewa.Application.CQRS.Images.Commands.DeleteImage;
using Tasogarewa.Application.CQRS.Images.Commands.UpdateImage;
using Tasogarewa.Application.CQRS.Images.Queries.GetImage;
using Tasogarewa.Application.CQRS.Images.Queries.GetImages;

namespace CoursesWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ImageController:BaseController
    {
        private readonly IMapper Mapper;
        public ImageController(IMapper mapper) => Mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<ImageListVm>> GetAll(Guid CourseId)
        {
            var query = new GetImagesQuery
            {
                CourseId = CourseId   
            };
            var vm = await mediator.Send(query);
            return Ok(vm);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageVm>> Get(Guid id)
        {
            var query = new GetCourseQuery
            {
                Id = id
            };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateImageDto  createImageDto)
        {
            var command = Mapper.Map<CreateImageCommand>(createImageDto);
            command.UserId = UserId;
            var ImageId = await mediator.Send(command);
            return Ok(ImageId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateImageDto  updateImageDto)
        {
            var command = Mapper.Map<UpdateImageCommand>(updateImageDto);
            command.UserId = UserId;
            await mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteImageCommand
            { Id = id, UserId = UserId };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
