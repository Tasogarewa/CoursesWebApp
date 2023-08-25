using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.ReviewComments.Commands.CreateReviewComment
{
    public class CreateReviewCommentCommandValidator:AbstractValidator<CreateReviewCommentCommand>
    {
        public CreateReviewCommentCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.ReviewId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(3000);


        }
    }
}
