using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Mentor> _mentorRepository;

        public CreateCourseCommandHandler(IRepository<Course> courseRepository, IRepository<Mentor> mentorRepository)
        {
            _courseRepository = courseRepository;
            _mentorRepository = mentorRepository;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var mentor = await _mentorRepository.GetAsync(request.MentorId);
            var course = await _courseRepository.Create(new Course() { Mentor = mentor, Name = request.Name, CourseTags = request.CourseTags,CreateAt = DateTime.Now, IsChecked=false });
            return course.Id;
        }
    }
}
