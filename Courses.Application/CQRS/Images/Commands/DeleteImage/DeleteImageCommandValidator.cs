using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Commands.DeleteImage
{
    public class DeleteImageCommandValidator:AbstractValidator<DeleteImageCommand>
    {
        public DeleteImageCommandValidator() 
        {
            RuleFor(image => image.UserId).NotEqual(Guid.Empty);
            RuleFor(image => image.Id).NotEqual(Guid.Empty);
        }
    }
}
