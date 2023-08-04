using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Commands.UpdateImage
{
    public class UpdateImageCommandValidator:AbstractValidator<UpdateImageCommand>
    {
        public UpdateImageCommandValidator()
        {
            RuleFor(image => image.Id).NotEqual(Guid.Empty);
            RuleFor(image => image.UserId).NotEqual(Guid.Empty);
            RuleFor(image => image.Path).NotEmpty();
        }
    }
}
