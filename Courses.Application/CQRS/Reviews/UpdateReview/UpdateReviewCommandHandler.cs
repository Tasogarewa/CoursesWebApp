using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Reviews.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Guid>
    {
        private readonly IRepository<Review> _reviewRepository;

        public UpdateReviewCommandHandler(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Guid> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetAsync(request.Id);
            if (review == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(review), request.Id);
            }
            else
            {
                review.UpdateAt = DateTime.Now;
                review.RatingOfReview = request.RatingOfReview;
                review.Images = request.Images;
                review.Text = request.Text;
                await _reviewRepository.Update(review);
            }
            return request.Id;

        }
    }
}
