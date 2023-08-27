using Azure.Core;
using Courses.Domain;
using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.UserLikedCourse.Commands.CreateUserLikedCourse;
using Tasogarewa.Application.CQRS.UserLikedCourse.Commands.DeleteUserLikedCourse;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class LikedCourseService : ILikedCourseService
    {
        private readonly IRepository<LikedCourse> _likedCourseRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<AppUser> _userRepository;

        public LikedCourseService(IRepository<LikedCourse> likedCourseRepository, IRepository<Course> courseRepository, IRepository<AppUser> userRepository)
        {
            _likedCourseRepository = likedCourseRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateLikedCourseAsync(CreateUserLikedCourseCommand createLikedCourse)
        {
            var user = await _userRepository.GetAsync(createLikedCourse.UserId);
            var course = await _courseRepository.GetAsync(createLikedCourse.CourseId);
            NotFoundException<AppUser>.Throw(user, createLikedCourse.UserId);
            NotFoundException<Course>.Throw(course, createLikedCourse.CourseId);
            var likedCourse = await _likedCourseRepository.CreateAsync(new LikedCourse { LikedCourses = user.LikedCourses, Course = course});
            return likedCourse.Id;
        }

        public async Task<Unit> DeleteLikedCourseAsync(DeleteUserLikedCourseCommand deleteLikedCourse)
        {
            var likedCourse = await _likedCourseRepository.GetAsync(deleteLikedCourse.Id);
            NotFoundException<LikedCourse>.Throw(likedCourse, deleteLikedCourse.Id);
            await _likedCourseRepository.DeleteAsync(likedCourse);
            return Unit.Value;
        }
    }
}
