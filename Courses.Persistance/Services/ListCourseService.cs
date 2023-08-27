using Azure.Core;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.InListCourses.Commands.CreateInListCourses;
using Tasogarewa.Application.CQRS.InListCourses.Commands.DeleteInListCourses;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class ListCourseService : IListCourseService
    {
        private readonly IRepository<Course> _courseRepository;
        public readonly IRepository<InListCourse> _inListCourseRepository;
        private readonly IRepository<UserNamedList> _userNamedListRepository;

        public ListCourseService(IRepository<Course> courseRepository, IRepository<InListCourse> inListCourseRepository, IRepository<UserNamedList> userNamedListRepository)
        {
            _courseRepository = courseRepository;
            _inListCourseRepository = inListCourseRepository;
            _userNamedListRepository = userNamedListRepository;
        }

        public async Task<Guid> CreateInListCourseAsync(CreateInListCourseCommand createInListCourse)
        {
            var course = await _courseRepository.GetAsync(createInListCourse.CourseId);
            var userNamedList = await _userNamedListRepository.GetAsync(createInListCourse.UserNamedListId);
            NotFoundException<Course>.Throw(course, createInListCourse.CourseId);
            NotFoundException<UserNamedList>.Throw(userNamedList, createInListCourse.UserNamedListId);
            var inListCourse = await _inListCourseRepository.CreateAsync(new InListCourse() { Course = course, UserNamedList = userNamedList });
            return inListCourse.Id;
        }

        public async Task<Unit> DeleteInListCourseAsync(DeleteInListCourseCommand deleteInListCourse)
        {
            var inListCourse = await _inListCourseRepository.GetAsync(deleteInListCourse.Id);
            NotFoundException<InListCourse>.Throw(inListCourse, deleteInListCourse.Id);
            await _inListCourseRepository.DeleteAsync(inListCourse);
            return Unit.Value;
        }
    }
}
