using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.InBasketCourses.Commands.DeleteInBasketCourses
{
    public class DeleteInBasketCourseCommandHandler : IRequestHandler<DeleteInBasketCourseCommand, Unit>
    {
      private readonly IBasketCourseService _basketCourseService;

        public DeleteInBasketCourseCommandHandler(IBasketCourseService basketCourseService)
        {
            _basketCourseService = basketCourseService;
        }

        public async Task<Unit> Handle(DeleteInBasketCourseCommand request, CancellationToken cancellationToken)
        {
            return await _basketCourseService.DeleteInBasketCourseAsync(request);
        }
    }
}
