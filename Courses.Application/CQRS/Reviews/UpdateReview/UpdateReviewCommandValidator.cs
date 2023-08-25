using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tasogarewa.Application.CQRS.Reviews.UpdateReview
{
    public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.RatingOfReview).NotEmpty();
            RuleFor(x => x.Text).NotEmpty().MinimumLength(50).MaximumLength(500);
        }
    }
}
