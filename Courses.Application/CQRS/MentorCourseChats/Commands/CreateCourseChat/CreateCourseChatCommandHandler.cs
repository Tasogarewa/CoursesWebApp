using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat
{
    public class CreateCourseChatCommandHandler : IRequestHandler<CreateCourseChatCommand, Guid>
    {
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<CourseChat> _courseChatRepository;

        public CreateCourseChatCommandHandler(IRepository<Mentor> mentorRepository, IRepository<Course> courseRepository, IRepository<CourseChat> courseChatRepository)
        {
            _mentorRepository = mentorRepository;
            _courseRepository = courseRepository;
            _courseChatRepository = courseChatRepository;
        }

        public async Task<Guid> Handle(CreateCourseChatCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(request.CourseId);
            var mentor = await _mentorRepository.GetAsync(request.MentorId);
            List<AppUser> users = new List<AppUser>();
            foreach(var user in course.CourseStudents)
            {
                users.Add(user.User);
            }
            var courseChat = await _courseChatRepository.Create(new CourseChat() { Course = course, Users = users, Mentor = mentor, Name = request.Name }); 
            return courseChat.Id;
        }
    }
}
