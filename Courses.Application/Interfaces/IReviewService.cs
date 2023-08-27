using MediatR;
using Tasogarewa.Application.CQRS.CourseReviews.Commands.CreateCourseReview;
using Tasogarewa.Application.CQRS.MentorReviews.CreateMentorReview;
using Tasogarewa.Application.CQRS.Reviews.DeleteReview;
using Tasogarewa.Application.CQRS.Reviews.UpdateReview;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface IReviewService
    {
        public Task<Guid> CreateCourseReviewAsync(CreateCourseReviewCommand createCourseReview);
        public Task<Guid> CreateMentorReviewsAsync(CreateMentorReviewCommand createMentorReview);
        public Task<Guid> UpdateReviewAsync(UpdateReviewCommand updateReview);
        public Task<Unit> DeleteReviewAsync(DeleteReviewCommand deleteReview);
    }
}
