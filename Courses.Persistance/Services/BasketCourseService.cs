using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket;
using Tasogarewa.Application.CQRS.InBasketCourses.Commands.CreateInBasketCourses;
using Tasogarewa.Application.CQRS.InBasketCourses.Commands.DeleteInBasketCourses;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class BasketCourseService : IBasketCourseService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IRepository<InBasketCourse> _inBasketCourseRepository;
        private readonly IRepository<Course> _courseRepository;

        public BasketCourseService(IRepository<Basket> basketRepository, IRepository<InBasketCourse> inBasketCourseRepository, IRepository<Course> courseRepository)
        {
            _basketRepository = basketRepository;
            _inBasketCourseRepository = inBasketCourseRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Guid> CreateInBasketCourseAsync(CreateInBasketCourseCommand createInBasketCourse)
        {
            var course = await _courseRepository.GetAsync(createInBasketCourse.CurseId);
            NotFoundException<Course>.Throw(course, createInBasketCourse.CurseId);
            var basket = await _basketRepository.GetAsync(createInBasketCourse.BasketId);
            NotFoundException<Basket>.Throw(basket, createInBasketCourse.BasketId);
            var inBasketCourse = await _inBasketCourseRepository.CreateAsync(new InBasketCourse() { Basket = basket, Course = course });
            return inBasketCourse.Id;
        }

        public async Task<Unit> DeleteInBasketCourseAsync(DeleteInBasketCourseCommand deleteInBasketCourse)
        {
            var inBasketCourse = await _inBasketCourseRepository.GetAsync(deleteInBasketCourse.Id);
            NotFoundException<InBasketCourse>.Throw(inBasketCourse, deleteInBasketCourse.Id);
            await _inBasketCourseRepository.DeleteAsync(inBasketCourse);
            return Unit.Value;
        }
    }
}
