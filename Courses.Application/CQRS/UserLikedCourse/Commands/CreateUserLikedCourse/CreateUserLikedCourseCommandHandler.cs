using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserLikedCourse.Commands.CreateUserLikedCourse
{
    public class CreateUserLikedCourseCommandHandler : IRequestHandler<CreateUserLikedCourseCommand, Guid>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<LikedCourse> _likedCourse;
        private readonly IRepository<AppUser> _userRepository;

        public CreateUserLikedCourseCommandHandler(IRepository<Course> courseRepository, IRepository<LikedCourse> likedCourse, IRepository<AppUser> userRepository)
        {
            _courseRepository = courseRepository;
            _likedCourse = likedCourse;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserLikedCourseCommand request, CancellationToken cancellationToken)
        {
          var course = await _courseRepository.GetAsync(request.CourseId);
            var user = await _userRepository.GetAsync(request.UserId);
          var likedCourse = await _likedCourse.Create(new LikedCourse { LikedCourses = user.LikedCourses, Course = await _courseRepository.GetAsync(request.CourseId)});
            return likedCourse.Id;
        }
    }
}
