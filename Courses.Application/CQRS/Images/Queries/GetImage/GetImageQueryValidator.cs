using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImage
{
    public class GetImageQueryValidator:AbstractValidator<GetImageQuery>
    {
        public GetImageQueryValidator() 
        {
            RuleFor(image => image.Id).NotEqual(Guid.Empty);
        }
    }
}
