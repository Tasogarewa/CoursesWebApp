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
      private readonly IReviewService _reviewService;

        public UpdateReviewCommandHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<Guid> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            return await _reviewService.UpdateReviewAsync(request);

        }
    }
}
