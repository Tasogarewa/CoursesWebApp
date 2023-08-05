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
        private readonly IRepository<Course> CoursesRepository;
        public UpdateCourseCommandHandler(IRepository<Course> repository)
        {
            CoursesRepository = repository;
        }
        public async Task<Guid> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await CoursesRepository.GetAsync(request.Id);
            if (course == null || course.Id != request.Id||course.appUser.Id!=request.UserId)
            {
                throw new NotFoundException(nameof(course), request.Id);
            }
            else
            {
                course.UpdateAt = DateTime.Now;
                course.Expires = request.Expires;
                course.Description = request.Description;
                course.FilePath = request.FilePath;
                course.Name = request.Name;
                course.Price=request.Price;
                course.Images = request.Images;
                CoursesRepository.Update(course);
                return request.Id;
            }
        }
    }
}
