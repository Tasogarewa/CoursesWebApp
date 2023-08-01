using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly IRepository<Course> CoursesRepository;


        public DeleteCourseCommandHandler(Repository<Course> repository)
        {
            CoursesRepository = repository;

        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await CoursesRepository.GetAsync(request.Id);
            if (course == null || course.Id != request.Id)
            {
                throw new NotFoundException(nameof(course), request.Id);
            }
            else
                CoursesRepository.Delete(course);
            return Unit.Value;
        }
    }
}
