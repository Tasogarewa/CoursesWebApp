using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.DeleteWishedCourse
{
    public class DeleteWishedCourseCommandHandler : IRequestHandler<DeleteWishedCourseCommand, Unit>
    {
        private readonly IRepository<UserWishedCourse> _wishedCourseRepository;

        public DeleteWishedCourseCommandHandler(IRepository<UserWishedCourse> wishedCourseRepository)
        {
            _wishedCourseRepository = wishedCourseRepository;
        }

        public async Task<Unit> Handle(DeleteWishedCourseCommand request, CancellationToken cancellationToken)
        {
            var wishedCourse = await _wishedCourseRepository.GetAsync(request.Id);
            if (wishedCourse == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(wishedCourse), request.Id);
            }
            else
                _wishedCourseRepository.Delete(wishedCourse);
            return Unit.Value;
        }
    }
}
