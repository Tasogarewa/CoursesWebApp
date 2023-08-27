
using MediatR;
using Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.CreateArchivedCourse;
using Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.DeleteArchivedCourse;

namespace Tasogarewa.Application.Interfaces
{
    public interface IArchivedCourseService
    {
        public Task<Guid> CreateArchivedCourseAsync(CreateArchivedCourseCommand createArchivedCourse);
        public Task<Unit> DeleteArchivedCourseAsync(DeleteArchivedCourseCommand deleteArchivedCourse);
    }
}
