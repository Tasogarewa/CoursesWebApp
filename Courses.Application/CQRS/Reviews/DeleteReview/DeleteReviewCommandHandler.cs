using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Reviews.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly IRepository<Review> _reviewRepository;

        public DeleteReviewCommandHandler(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetAsync(request.Id);
            if (review == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(review), request.Id);
            }
            else
            {
               await _reviewRepository.Delete(review);
                return Unit.Value;
            }
        }
    }
}
