using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Commands.CreateImage
{
    public class CreateImageCommandValidator:AbstractValidator<CreateImageCommand>
    {
        public CreateImageCommandValidator() 
        {
            RuleFor(image => image.UserId).NotEqual(Guid.Empty);
            RuleFor(image => image.Path).NotEmpty();
            RuleFor(image => image.CourseId).NotEqual(Guid.Empty);
        }
    }
}
