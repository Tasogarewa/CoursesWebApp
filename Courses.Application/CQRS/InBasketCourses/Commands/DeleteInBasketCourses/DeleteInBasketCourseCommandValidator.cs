using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.InBasketCourses.Commands.DeleteInBasketCourses
{
    public class DeleteInBasketCourseCommandValidator:AbstractValidator<DeleteInBasketCourseCommand>
    {
        public DeleteInBasketCourseCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
