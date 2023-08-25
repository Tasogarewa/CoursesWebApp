using MediatR;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Mentors.Commands.UpdateMentor
{
    public class UpdateMentorCommandHandler : IRequestHandler<UpdateMentorCommand, Guid>
    {
        private readonly IRepository<Mentor> _mentorRepository;

        public UpdateMentorCommandHandler(IRepository<Mentor> mentorRepository)
        {
            _mentorRepository = mentorRepository;
        }

        public async Task<Guid> Handle(UpdateMentorCommand request, CancellationToken cancellationToken)
        {
            var mentor = await _mentorRepository.GetAsync(request.Id);
            if (mentor == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(mentor), request.Id);
            }
            else
            {
                mentor.Description = request.Description;
                mentor.Email = request.Email;
                mentor.Facebook=request.Facebook;
                mentor.Twitter=request.Twitter;
                mentor.YouTube=request.YouTube;
                mentor.Phone=request.Phone;
                mentor.GitHub=request.GitHub;
                mentor.Web = request.Web;
                mentor.Image=request.Image;
                mentor.Name=request.Name;
                mentor.Surname=request.Surname;
                mentor.Instagram=request.Instagram;
               await _mentorRepository.Update(mentor);
            }
            return mentor.Id;
        }
    }
}
