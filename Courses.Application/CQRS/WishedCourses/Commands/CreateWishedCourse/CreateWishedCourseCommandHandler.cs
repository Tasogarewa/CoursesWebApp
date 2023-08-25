using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.CreateWishedCourse
{
    public class CreateWishedCourseCommandHandler : IRequestHandler<CreateWishedCourseCommand, Guid>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<UserWishedCourse> _wishedCourseRepository;
        private readonly IRepository<AppUser> _userRepository;

        public CreateWishedCourseCommandHandler(IRepository<Course> courseRepository, IRepository<UserWishedCourse> wishedCourseRepository, IRepository<AppUser> userRepository)
        {
            _courseRepository = courseRepository;
            _wishedCourseRepository = wishedCourseRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateWishedCourseCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var wishedCourse = await _wishedCourseRepository.Create(new UserWishedCourse() { WishList=user.UserWishList, Course = await _courseRepository.GetAsync(request.CourseId) });

            return wishedCourse.Id;
        }
    }
}
