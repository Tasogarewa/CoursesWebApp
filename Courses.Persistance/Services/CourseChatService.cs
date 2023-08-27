using AutoMapper;
using Azure.Core;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.DeleteCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Commands.UpdateCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChat;
using Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChats;
using Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat;
using Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChats;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class CourseChatService : ICourseChatService
    {
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<CourseChat> _courseChatRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper; 
        public CourseChatService(IRepository<Mentor> mentorRepository, IRepository<AppUser> userRepository, IRepository<CourseChat> courseChatRepository, IRepository<Course> courseRepository, IMapper mapper)
        {
            _mentorRepository = mentorRepository;
            _userRepository = userRepository;
            _courseChatRepository = courseChatRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCourseChatAsync(CreateCourseChatCommand createCourseChat)
        {
            var course = await _courseRepository.GetAsync(createCourseChat.CourseId);
            var mentor = await _mentorRepository.GetAsync(createCourseChat.MentorId);
            NotFoundException<Course>.Throw(course, createCourseChat.CourseId);
            NotFoundException<Mentor>.Throw(mentor, createCourseChat.MentorId);
            List<AppUser> users = new List<AppUser>();
            foreach (var user in course.CourseStudents)
            {
                users.Add(user.User);
            }
            var courseChat = await _courseChatRepository.CreateAsync(new CourseChat() { Course = course, Users = users, Mentor = mentor, Name = createCourseChat.Name });
            return courseChat.CourseId;
        }

        public async Task<Unit> DeleteCourseChatAsync(DeleteCourseChatCommand deleteCourseChat)
        {
            var courseChat = await _courseChatRepository.GetAsync(deleteCourseChat.Id);
            NotFoundException<CourseChat>.Throw(courseChat, deleteCourseChat.Id);
            await _courseChatRepository.DeleteAsync(courseChat);
            return Unit.Value;
        }

        public async Task<MentorCourseChatVm> GetMentorCourseChatAsync(GetMentorCourseChatQuery getMentorCourseChat)
        {
            var courseChat = await _courseChatRepository.GetAsync(getMentorCourseChat.Id);
            NotFoundException<CourseChat>.Throw(courseChat, getMentorCourseChat.Id);
            return _mapper.Map<MentorCourseChatVm>(courseChat);
        }

        public async Task<MentorCourseChatListVm> GetMentorCourseChatsAsync(GetMentorCourseChatsQuery getMentorCourseChats)
        {
            var courseChats = await _courseChatRepository.GetAllAsync();
            NotFoundException<CourseChat>.ThrowRange(courseChats.ToList(), getMentorCourseChats.MentorId);
            return new MentorCourseChatListVm() { courseChatDtos =  _mapper.ProjectTo<MentorCourseChatDto>(courseChats.Where(x => x.MentorId == getMentorCourseChats.MentorId).AsQueryable()).ToList() };
        }

        public async Task<UserCourseChatVm> GetUserCourseChatAsync(GetUserCourseChatQuery getUserCourseChat)
        {

            var courseChat = await _courseChatRepository.GetAsync(getUserCourseChat.Id);
            NotFoundException<CourseChat>.Throw(courseChat, getUserCourseChat.Id);
            return _mapper.Map<UserCourseChatVm>(courseChat);
        }

        public async Task<UserCourseChatListVm> GetUserCourseChatsAsync(GetUserCourseChatsQuery getUserCourseChats)
        {
            var user = await _userRepository.GetAsync(getUserCourseChats.UserId);
            var courseChats = await _courseChatRepository.GetAllAsync();
            NotFoundException<AppUser>.Throw(user, getUserCourseChats.UserId);
            NotFoundException<CourseChat>.ThrowRange(courseChats.ToList(), getUserCourseChats.UserId);
            return new UserCourseChatListVm() {  courseChatDtos = _mapper.ProjectTo<UserCourseChatDto>(courseChats.Where(x => x.Users.Contains(user)).AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateCourseChatAsync(UpdateCourseChatCommand updateCourseChat)
        {
            var courseChat = await _courseChatRepository.GetAsync(updateCourseChat.Id);
            NotFoundException<CourseChat>.Throw(courseChat, updateCourseChat.Id);
            courseChat.Name = updateCourseChat.Name;
            await _courseChatRepository.UpdateAsync(courseChat);
            return courseChat.Id;
        }
    }
}
