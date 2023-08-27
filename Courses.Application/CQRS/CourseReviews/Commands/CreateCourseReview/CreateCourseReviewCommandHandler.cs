using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CourseReviews.Commands.CreateCourseReview
{
    public class CreateCourseReviewCommandHandler:IRequestHandler<CreateCourseReviewCommand,Guid>
    {
        private readonly IReviewService _reviewService;

        public CreateCourseReviewCommandHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<Guid> Handle(CreateCourseReviewCommand request, CancellationToken cancellationToken)
        {
            return await _reviewService.CreateCourseReviewAsync(request);
        }

    }
}
