using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.AnnouncmentComments.Commands.CreateAnnouncmentComment;
using Tasogarewa.Application.CQRS.Comments.DeleteComment;
using Tasogarewa.Application.CQRS.Comments.UpdateComment;
using Tasogarewa.Application.CQRS.CourseComments.Commands.CreateCourseComment;
using Tasogarewa.Application.CQRS.MentorComments.Commands.CreateMentorComment;
using Tasogarewa.Application.CQRS.ReviewComments.Commands.CreateReviewComment;

namespace CoursesWebAPI.Controllers
{
    public class CommentsController:BaseController
    {
      
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAnnouncmentComment([FromBody] CreateAnnouncmentCommentCommand createAnnouncmentComment)
        {
            var announcmentCommentId = await Mediator.Send(createAnnouncmentComment);
            return Ok(announcmentCommentId);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCourseComment([FromBody] CreateCourseCommentCommand createCourseCommentCommand)
        {
            var courseCommentId  = await Mediator.Send(createCourseCommentCommand);
            return Ok(courseCommentId);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateReviewComment([FromBody] CreateReviewCommentCommand  createReviewCommentCommand)
        {
            var reviewCommentId = await Mediator.Send(createReviewCommentCommand);
            return Ok(reviewCommentId);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMentorComment([FromBody] CreateMentorCommentCommand createMentorCommentCommand)
        {
            var mentorCommentId = await Mediator.Send(createMentorCommentCommand);
            return Ok(mentorCommentId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteCommentCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCommentCommand  updateCommentCommand)
        {
            await Mediator.Send(updateCommentCommand);
            return NoContent();
        }
    }
}
