
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.CreateAnnouncments
{
    public class CreateAnnouncmentCommandHandler : IRequestHandler<CreateAnnouncmentCommand, Guid>
    {
        private readonly IRepository<Announcement> _announcmentsRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Mentor> _mentorRepository;

        public CreateAnnouncmentCommandHandler(IRepository<Announcement> announcmentsRepository, IRepository<Course> courseRepository, IRepository<Mentor> mentorRepository)
        {
            _announcmentsRepository = announcmentsRepository;
            _courseRepository = courseRepository;
            _mentorRepository = mentorRepository;
        }

        public async Task<Guid> Handle(CreateAnnouncmentCommand request, CancellationToken cancellationToken)
        {
            var announcment = await _announcmentsRepository.Create(new Announcement() { Course = await _courseRepository.GetAsync(request.CourseId), CreateAt = DateTime.Now, Images = request.Images, Text = request.Text, Mentor = await _mentorRepository.GetAsync(request.MentorId) });
            return announcment.Id; 
        }
    }
}
