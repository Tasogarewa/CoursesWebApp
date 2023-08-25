using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CourseStudents.Commands.CreateCourseStudents
{
    public class CreateCourseStudentCommandHandler : IRequestHandler<CreateCourseStudentCommand, Guid>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<CourseStudent> _courseStudentRepository;

        public CreateCourseStudentCommandHandler(IRepository<Course> courseRepository, IRepository<AppUser> userRepository, IRepository<CourseStudent> courseStudentRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<Guid> Handle(CreateCourseStudentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var course = await _courseRepository.GetAsync(request.CourseId);
            int lectionCount = 0;
            foreach(var item in course.Sections)
            {
                lectionCount+=item.Lections.Count;
                
            }
            var courseStudent = await _courseStudentRepository.Create(new CourseStudent() { Course = course, User = user, Lections = lectionCount, CompletedLections = 0 });
        return courseStudent.Id;  
         }
    }
}
