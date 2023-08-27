using Courses.Domain;
using MediatR;
using Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;

namespace Tasogarewa.Application.Interfaces
{
    public interface ICourseService
    {
        public Task<CourseVm> GetCourseAsync(GetCourseQuery getCourse);
        public Task<CourseListVm> GetCoursesAsync();
        public Task<CourseListVm> GetMentorCoursesAsync(GetMentorCoursesQuery getMentorCourses);
        public Task<Guid> CreateCourseAsync(CreateCourseCommand createCourse);
        public Task<Guid> UpdateCourseAsync(UpdateCourseCommand updateCourse);
        public Task<Unit> DeleteCourseAsync(DeleteCourseCommand deleteCourse);

    }
}
