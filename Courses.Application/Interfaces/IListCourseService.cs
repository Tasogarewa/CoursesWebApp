
using MediatR;
using Tasogarewa.Application.CQRS.InListCourses.Commands.CreateInListCourses;
using Tasogarewa.Application.CQRS.InListCourses.Commands.DeleteInListCourses;

namespace Tasogarewa.Application.Interfaces
{
    public interface IListCourseService
    {
        public Task<Guid> CreateInListCourseAsync(CreateInListCourseCommand createInListCourse);
        public Task<Unit> DeleteInListCourseAsync(DeleteInListCourseCommand deleteInListCourse);
    }
}
