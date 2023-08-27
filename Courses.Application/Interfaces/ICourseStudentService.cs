using Tasogarewa.Application.CQRS.CourseStudents.Commands.CreateCourseStudents;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface ICourseStudentService
    {
        public Task<Guid> CreateCourseStudentAsync(CreateCourseStudentCommand createCourseStudent);
    }
}
