
using MediatR;
using Tasogarewa.Application.CQRS.UserLikedCourse.Commands.CreateUserLikedCourse;
using Tasogarewa.Application.CQRS.UserLikedCourse.Commands.DeleteUserLikedCourse;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface ILikedCourseService
    {
        public Task<Guid> CreateLikedCourseAsync(CreateUserLikedCourseCommand createLikedCourse);
        public Task<Unit> DeleteLikedCourseAsync(DeleteUserLikedCourseCommand deleteLikedCourse);
    }
}
