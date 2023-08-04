using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Comments.Queries.GetComments
{
    public class GetCommentsQueryValidator:AbstractValidator<GetCommentsQuery>
    {
        public GetCommentsQueryValidator()
        {
            RuleFor(comments => comments.CourseId).NotEqual(Guid.Empty);
        }
    }
}
