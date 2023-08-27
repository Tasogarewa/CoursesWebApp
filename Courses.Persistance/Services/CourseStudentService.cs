using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.CourseStudents.Commands.CreateCourseStudents;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class CourseStudentService : ICourseStudentService
    {
        private readonly IRepository<Course> _couresRepository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<CourseStudent> _courseStudentRepository;

        public CourseStudentService(IRepository<Course> couresRepository, IRepository<AppUser> userRepository, IRepository<CourseStudent> courseStudentRepository)
        {
            _couresRepository = couresRepository;
            _userRepository = userRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<Guid> CreateCourseStudentAsync(CreateCourseStudentCommand createCourseStudent)
        {
            var user = await _userRepository.GetAsync(createCourseStudent.UserId);
            var course = await _couresRepository.GetAsync(createCourseStudent.CourseId);
            NotFoundException<AppUser>.Throw(user, createCourseStudent.UserId);
            NotFoundException<Course>.Throw(course, createCourseStudent.CourseId);
            int lectionCount = 0;
            foreach (var item in course.Sections)
            {
                lectionCount += item.Lections.Count;

            }
            var courseStudent = await _courseStudentRepository.CreateAsync(new CourseStudent() { Course = course, User = user, Lections = lectionCount, CompletedLections = 0 });
            return courseStudent.Id;
        }
    }
}
