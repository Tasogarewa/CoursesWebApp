using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.InBasketCourses.Commands.CreateInBasketCourses
{
    public class CreateInBasketCourseCommandHandler : IRequestHandler<CreateInBasketCourseCommand, Guid>
    {
     private readonly IBasketCourseService _basketCourseService;

        public CreateInBasketCourseCommandHandler(IBasketCourseService basketCourseService)
        {
            _basketCourseService = basketCourseService;
        }

        public async Task<Guid> Handle(CreateInBasketCourseCommand request, CancellationToken cancellationToken)
        {
            return await _basketCourseService.CreateInBasketCourseAsync(request);
        }
    }
}
