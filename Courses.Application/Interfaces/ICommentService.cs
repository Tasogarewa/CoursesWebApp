using Courses.Domain;
using MediatR;
using Tasogarewa.Application.CQRS.AnnouncmentComments.Commands.CreateAnnouncmentComment;
using Tasogarewa.Application.CQRS.Comments.DeleteComment;
using Tasogarewa.Application.CQRS.Comments.UpdateComment;
using Tasogarewa.Application.CQRS.CourseComments.Commands.CreateCourseComment;
using Tasogarewa.Application.CQRS.MentorComments.Commands.CreateMentorComment;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat;
using Tasogarewa.Application.CQRS.ReviewComments.Commands.CreateReviewComment;

namespace Tasogarewa.Application.Interfaces
{
    public interface ICommentService
    {
        public Task<Guid> CreateCourseCommentAsync(CreateCourseCommentCommand createCourseComment);
        public Task<Guid> CreateAnnouncmentCommentAsync(CreateAnnouncmentCommentCommand createAnnouncmentComment);
        public Task<Guid> CreateReviewCommentAsync(CreateReviewCommentCommand createReviewComment);
        public Task<Guid> CreateMentorCommentAsync(CreateMentorCommentCommand createMentorComment);
        public Task<Guid> UpdateCommentAsync(UpdateCommentCommand updateCommentCommand);
        public Task<Unit> DeleteCommentAsync(DeleteCommentCommand deleteCommentCommand);
    }
}
