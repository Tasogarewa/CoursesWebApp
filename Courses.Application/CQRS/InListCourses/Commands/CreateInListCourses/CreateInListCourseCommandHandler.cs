using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.InListCourses.Commands.CreateInListCourses
{
    public class CreateInListCourseCommandHandler : IRequestHandler<CreateInListCourseCommand, Guid>
    {
        private readonly IRepository<Course> _courseRepository;
        public readonly IRepository<InListCourse> _inListCourse;
        private readonly IRepository<UserNamedList> _userNamedList;

        public CreateInListCourseCommandHandler(IRepository<Course> courseRepository, IRepository<InListCourse> inListCourse, IRepository<UserNamedList> userNamedList)
        {
            _courseRepository = courseRepository;
            _inListCourse = inListCourse;
            _userNamedList = userNamedList;
        }

        public async Task<Guid> Handle(CreateInListCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(request.CourseId);
            var userNamedList = await _userNamedList.GetAsync(request.UserNamedListId);
            var inListCourse = await _inListCourse.Create(new InListCourse() { Course = course, UserNamedList = userNamedList });
            return inListCourse.Id;
        }
    }
}
