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

namespace Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Guid>
    {
        private readonly IRepository<Course> _courseRepository;

        public UpdateCourseCommandHandler(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Guid> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(request.Id);
            if (course == null ||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(course), request.Id);
            }
            else
            {
                course.UpdateAt = DateTime.Now;
                course.Description = request.Description;
                course.Name = request.Name;
                course.Price=request.Price;
                course.Images = request.Images;
                course.Sections  = request.Sections;
                course.Requierments = request.Requierments;
                course.Goals = request.Goals;
                 await _courseRepository.Update(course);
                return request.Id;
            }
        }
    }
}
