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
        private readonly IRepository<InBasketCourse> _inBasketCourse;

        public DeleteInBasketCourseCommandHandler(IRepository<InBasketCourse> inBasketCourse)
        {
            _inBasketCourse = inBasketCourse;
        }

        public async Task<Unit> Handle(DeleteInBasketCourseCommand request, CancellationToken cancellationToken)
        {
           var inBasketCourse = await _inBasketCourse.GetAsync(request.Id);
            if (inBasketCourse == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(inBasketCourse), request.Id);
            }
            else
               await _inBasketCourse.Delete(inBasketCourse);
            return Unit.Value;
        }
    }
}
