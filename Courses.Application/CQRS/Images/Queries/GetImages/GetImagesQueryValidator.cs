using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImages
{
    public class GetImagesQueryValidator:AbstractValidator<GetImagesQuery>
    {
        public GetImagesQueryValidator()
        {
            RuleFor(image => image.CourseId).NotEqual(Guid.Empty);
        }
    }
}
