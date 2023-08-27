using AutoMapper;
using Azure.Core;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.CreateArchivedCourse;
using Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.DeleteArchivedCourse;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class ArchivedCourseService : IArchivedCourseService
    {
        private readonly IRepository<ArchivedCourse> _archivedCourseRepository;
        private readonly IRepository<Course> _courseCourseRepository;

        public ArchivedCourseService(IRepository<ArchivedCourse> archivedCourseRepository, IRepository<Course> courseCourseRepository)
        {
            _archivedCourseRepository = archivedCourseRepository;
            _courseCourseRepository = courseCourseRepository;
        }

        public async Task<Guid> CreateArchivedCourseAsync(CreateArchivedCourseCommand createArchivedCourse)
        {
            var course = await _courseCourseRepository.GetAsync(createArchivedCourse.CourseId);
            NotFoundException<Course>.Throw(course, createArchivedCourse.CourseId);
            var archivedCourse = await _archivedCourseRepository.CreateAsync(new ArchivedCourse() { Course = course });
            return archivedCourse.Id;
        }

        public async Task<Unit> DeleteArchivedCourseAsync(DeleteArchivedCourseCommand deleteArchivedCourse)
        {
            var archivedCourse = await _archivedCourseRepository.GetAsync(deleteArchivedCourse.Id);
            NotFoundException<ArchivedCourse>.Throw(archivedCourse, deleteArchivedCourse.Id);
            await _archivedCourseRepository.DeleteAsync(archivedCourse);
            return Unit.Value;
        }
    }
}
