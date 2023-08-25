using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Mentors.Queries.GetMentors
{
    public class GetMentorsQueryHandler : IRequestHandler<GetMentorsQuery, MentorListVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Mentor> _mentorRepository;

        public GetMentorsQueryHandler(IMapper mapper, IRepository<Mentor> mentorRepository)
        {
            _mapper = mapper;
            _mentorRepository = mentorRepository;
        }

        public async Task<MentorListVm> Handle(GetMentorsQuery request, CancellationToken cancellationToken)
        {
            var mentors = await _mentorRepository.GetAllAsync();
            if (mentors == null)
            {
                throw new NotFoundException(nameof(mentors), 0);
            }
            else
                return new MentorListVm() { mentorDtos = await _mapper.ProjectTo<MentorDto>((IQueryable)mentors).ToListAsync() };
        }
    }
}
