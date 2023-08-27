using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Mentors.Commands.UpdateMentor;
using Tasogarewa.Application.CQRS.Mentors.Queries.GetMentor;
using Tasogarewa.Application.CQRS.Mentors.Queries.GetMentors;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class MentorService : IMentorService
    {
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IMapper _mapper;

        public MentorService(IRepository<Mentor> mentorRepository, IMapper mapper)
        {
            _mentorRepository = mentorRepository;
            _mapper = mapper;
        }

        public async Task<MentorVm> GetMentorAsync(GetMentorQuery getMentor)
        {
          var mentor = await _mentorRepository.GetAsync(getMentor.Id);
            NotFoundException<Mentor>.Throw(mentor, getMentor.Id);
            return _mapper.Map<MentorVm>(mentor);
        }

        public async Task<MentorListVm> GetMentorsAsync()
        {
            var mentors = await _mentorRepository.GetAllAsync();
            return new MentorListVm() { mentorDtos =  _mapper.ProjectTo<MentorDto>(mentors.AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateMentorAsync(UpdateMentorCommand updateMentor)
        {
            var mentor = await _mentorRepository.GetAsync(updateMentor.Id);
            NotFoundException<Mentor>.Throw(mentor, updateMentor.Id);
            mentor.Description = updateMentor.Description;
            mentor.Email = updateMentor.Email;
            mentor.Facebook = updateMentor.Facebook;
            mentor.Twitter = updateMentor.Twitter;
            mentor.YouTube = updateMentor.YouTube;
            mentor.Phone = updateMentor.Phone;
            mentor.GitHub = updateMentor.GitHub;
            mentor.Web = updateMentor.Web;
            mentor.Image = updateMentor.Image;
            mentor.Name = updateMentor.Name;
            mentor.Surname = updateMentor.Surname;
            mentor.Instagram = updateMentor.Instagram;
            await _mentorRepository.UpdateAsync(mentor);
            return mentor.Id;
        }
    }
}
