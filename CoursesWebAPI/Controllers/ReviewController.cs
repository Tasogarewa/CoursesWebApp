using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasogarewa.Application.CQRS.CourseReviews.Commands.CreateCourseReview;
using Tasogarewa.Application.CQRS.MentorReviews.CreateMentorReview;
using Tasogarewa.Application.CQRS.Reviews.DeleteReview;
using Tasogarewa.Application.CQRS.Reviews.UpdateReview;

namespace CoursesWebAPI.Controllers
{
    public class ReviewController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMentorReview([FromBody] CreateMentorReviewCommand  createMentorReviewCommand)
        {
            var mentorReviewId = await Mediator.Send(createMentorReviewCommand);
            return Ok(mentorReviewId);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCourseReview([FromBody] CreateCourseReviewCommand createCourseReviewCommand )
        {
            var courseReviewId = await Mediator.Send(createCourseReviewCommand);
            return Ok(courseReviewId);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteReviewCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateReviewCommand  updateReviewCommand)
        {
            await Mediator.Send(updateReviewCommand);
            return NoContent();
        }
    }
}
