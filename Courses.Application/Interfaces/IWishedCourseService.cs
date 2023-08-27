
using MediatR;
using Tasogarewa.Application.CQRS.WishedCourses.Commands.CreateWishedCourse;
using Tasogarewa.Application.CQRS.WishedCourses.Commands.DeleteWishedCourse;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface IWishedCourseService
    {
        public Task<Guid> CreateWishedCourseAsync(CreateWishedCourseCommand createWishedCourse);
        public Task<Unit> DeleteWishedCourseAsync(DeleteWishedCourseCommand deleteWishedCourse);
    }
}
