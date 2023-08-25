using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CourseReviews.Commands.CreateCourseReview
{
    public class CreateCourseReviewCommandValidator:AbstractValidator<CreateCourseReviewCommand>
    {
        public CreateCourseReviewCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x => x.RatingOfReview).NotEmpty();
            RuleFor(x => x.Text).NotEmpty().MinimumLength(50).MaximumLength(500);



        }
    }
}
