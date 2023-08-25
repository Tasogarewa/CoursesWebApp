using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorReviews.CreateMentorReview
{
    public class CreateMentorReviewCommandValidator:AbstractValidator<CreateMentorReviewCommand>
    {
        public CreateMentorReviewCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.MentorId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).NotEmpty().MinimumLength(50).MaximumLength(500);
        }
    }
}
