using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.InBasketCourses.Commands.CreateInBasketCourses
{
    public class CreateInBasketCourseCommandValidator:AbstractValidator<CreateInBasketCourseCommand>
    {
        public CreateInBasketCourseCommandValidator() 
        {
            RuleFor(x => x.CurseId).NotEqual(Guid.Empty);
            RuleFor(x => x.BasketId).NotEqual(Guid.Empty);

        }
    }
}
