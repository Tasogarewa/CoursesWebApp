using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorReviews.CreateMentorReview
{
    public class CreateMentorReviewCommandHandler : IRequestHandler<CreateMentorReviewCommand, Guid>
    {
        private readonly IReviewService _reviewService;

        public CreateMentorReviewCommandHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<Guid> Handle(CreateMentorReviewCommand request, CancellationToken cancellationToken)
        {
            return await _reviewService.CreateMentorReviewsAsync(request);
        }
    }
}
