using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.DeleteCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.UpdateCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChats;
using Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat;
using Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChats;
using Tasogarewa.Domain;

namespace CoursesWebAPI.Controllers
{
    public class CourseChatController:BasketController
    {
        [HttpGet]
        public async Task<ActionResult<UserCourseChatListVm>> GetAllUserCourseChats(Guid userId)
        {
            var query = new GetUserCourseChatsQuery
            {
               UserId = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<UserCourseChatVm>> GetUserCourseChat(Guid courseChatId)
        {
            var query = new GetUserCourseChatQuery
            {
               Id = courseChatId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<MentorCourseChatListVm>> GetAllMentorCourseChats(Guid mentorId)
        {
            var query = new GetMentorCourseChatsQuery
            {
                 MentorId = mentorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<MentorCourseChatVm>> GetMentorCourseChat(Guid courseChatId)
        {
            var query = new GetMentorCourseChatQuery
            {
                  Id = courseChatId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseChatCommand createCourseChatCommand)
        {
            var courseChatId = await Mediator.Send(createCourseChatCommand);
            return Ok(courseChatId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteCourseChatCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCourseChatCommand updateCourseChatCommand)
        {
            await Mediator.Send(updateCourseChatCommand);
            return NoContent();
        }
    }
}
