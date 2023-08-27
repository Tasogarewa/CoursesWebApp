
using MediatR;
using Tasogarewa.Application.CQRS.InBasketCourses.Commands.CreateInBasketCourses;
using Tasogarewa.Application.CQRS.InBasketCourses.Commands.DeleteInBasketCourses;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface IBasketCourseService
    {
        public Task<Guid> CreateInBasketCourseAsync(CreateInBasketCourseCommand createInBasketCourse);
        public Task<Unit> DeleteInBasketCourseAsync(DeleteInBasketCourseCommand deleteInBasketCourse);
    }
}
