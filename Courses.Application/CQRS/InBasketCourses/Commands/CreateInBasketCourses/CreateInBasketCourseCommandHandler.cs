using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.InBasketCourses.Commands.CreateInBasketCourses
{
    public class CreateInBasketCourseCommandHandler : IRequestHandler<CreateInBasketCourseCommand, Guid>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Basket> _basketRepository;
        private readonly IRepository<InBasketCourse> _inBasketCourse;

        public CreateInBasketCourseCommandHandler(IRepository<Course> courseRepository, IRepository<Basket> basketRepository, IRepository<InBasketCourse> inBasketCourse)
        {
            _courseRepository = courseRepository;
            _basketRepository = basketRepository;
            _inBasketCourse = inBasketCourse;
        }

        public async Task<Guid> Handle(CreateInBasketCourseCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetAsync(request.BasketId);
            var course = await _courseRepository.GetAsync(request.CurseId);
            var inBasketCourse = await _inBasketCourse.Create(new InBasketCourse() { Basket = basket, Course = course });
            return inBasketCourse.Id;
        }
    }
}
