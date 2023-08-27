using Azure.Core;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.WishedCourses.Commands.CreateWishedCourse;
using Tasogarewa.Application.CQRS.WishedCourses.Commands.DeleteWishedCourse;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class WishedCourseService : IWishedCourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<UserWishedCourse> _wishedCourseRepository;
        private readonly IRepository<AppUser> _userRepository;

        public WishedCourseService(IRepository<Course> courseRepository, IRepository<UserWishedCourse> wishedCourseRepository, IRepository<AppUser> userRepository)
        {
            _courseRepository = courseRepository;
            _wishedCourseRepository = wishedCourseRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateWishedCourseAsync(CreateWishedCourseCommand createWishedCourse)
        {
            var course = await _courseRepository.GetAsync(createWishedCourse.CourseId);
            var user = await _userRepository.GetAsync(createWishedCourse.UserId);
            NotFoundException<Course>.Throw(course, createWishedCourse.CourseId);
            NotFoundException<AppUser>.Throw(user, createWishedCourse.UserId);
            var wishedCourse = await _wishedCourseRepository.CreateAsync(new UserWishedCourse() { WishList = user.UserWishList, Course = course });
            return wishedCourse.Id;
        }

        public async Task<Unit> DeleteWishedCourseAsync(DeleteWishedCourseCommand deleteWishedCourse)
        {
            var wishedCourse = await _wishedCourseRepository.GetAsync(deleteWishedCourse.Id);
            NotFoundException<UserWishedCourse>.Throw(wishedCourse, deleteWishedCourse.Id);
            await _wishedCourseRepository.DeleteAsync(wishedCourse);
            return Unit.Value;
        }
    }
}
