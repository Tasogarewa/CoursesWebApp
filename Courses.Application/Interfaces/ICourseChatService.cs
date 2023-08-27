
using MediatR;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.DeleteCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.UpdateCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChats;
using Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat;
using Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChats;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface ICourseChatService
    {
        public Task<MentorCourseChatVm> GetMentorCourseChatAsync(GetMentorCourseChatQuery getMentorCourseChat);
        public Task<MentorCourseChatListVm> GetMentorCourseChatsAsync(GetMentorCourseChatsQuery getMentorCourseChats);
        public Task<UserCourseChatListVm> GetUserCourseChatsAsync(GetUserCourseChatsQuery getUserCourseChats);
        public Task<UserCourseChatVm> GetUserCourseChatAsync(GetUserCourseChatQuery getUserCourseChat);
        public Task<Guid> CreateCourseChatAsync(CreateCourseChatCommand createCourseChat);
        public Task<Guid> UpdateCourseChatAsync(UpdateCourseChatCommand updateCourseChat);
        public Task<Unit> DeleteCourseChatAsync(DeleteCourseChatCommand deleteCourseChat);
    }
}
