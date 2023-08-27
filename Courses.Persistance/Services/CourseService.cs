using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourses;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IMapper _mapper;

        public CourseService(IRepository<Course> courseRepository, IRepository<Mentor> mentorRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mentorRepository = mentorRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCourseAsync(CreateCourseCommand createCourse)
        {
            var mentor = await _mentorRepository.GetAsync(createCourse.MentorId);
            NotFoundException<Mentor>.Throw(mentor, createCourse.MentorId);
            var course = await _courseRepository.CreateAsync(new Course() { Mentor = mentor, Name = createCourse.Name, CourseTags = createCourse.CourseTags, CreateAt = DateTime.Now, IsChecked = false });
            return course.Id;
        }
        public async Task<Unit> DeleteCourseAsync(DeleteCourseCommand deleteCourse)
        {
            var course = await _courseRepository.GetAsync(deleteCourse.Id);
            NotFoundException<Course>.Throw(course, deleteCourse.Id);
            await _courseRepository.DeleteAsync(course);
            return Unit.Value;
        }

        public async Task<CourseVm> GetCourseAsync(GetCourseQuery getCourse)
        {
            var course = await _courseRepository.GetAsync(getCourse.Id);
            NotFoundException<Course>.Throw(course, getCourse.Id);
            return _mapper.Map<CourseVm>(course);
        }

        public async Task<CourseListVm> GetCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return new CourseListVm() { courseDtos =  _mapper.ProjectTo<CourseDto>(courses.AsQueryable()).ToList() };
        }

        public async Task<CourseListVm> GetMentorCoursesAsync(GetMentorCoursesQuery getMentorCourses)
        {
            var mentor = await _mentorRepository.GetAsync(getMentorCourses.MentorId);
            var courses = await _courseRepository.GetAllAsync();
            NotFoundException<Course>.ThrowRange(courses.ToList(), getMentorCourses.MentorId);
            NotFoundException<Mentor>.Throw(mentor, getMentorCourses.MentorId);
            return new CourseListVm() { courseDtos = _mapper.ProjectTo<CourseDto>(courses.Where(x => x.Mentor == mentor).AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateCourseAsync(UpdateCourseCommand updateCourse)
        {
            var course = await _courseRepository.GetAsync(updateCourse.Id);
            NotFoundException<Course>.Throw(course, updateCourse.Id);
            course.UpdateAt = DateTime.Now;
            course.Description = updateCourse.Description;
            course.Name = updateCourse.Name;
            course.Price = updateCourse.Price;
            course.Images = updateCourse.Images;
            course.Sections = updateCourse.Sections;
            course.Requierments = updateCourse.Requierments;
            course.Goals = updateCourse.Goals;
            await _courseRepository.UpdateAsync(course);
           return course.Id;
        }
    }
}
