using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Mentors.Queries.GetMentor
{
    public class GetMentorQueryHandler : IRequestHandler<GetMentorQuery, MentorVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Mentor> _mentorRepository;

        public GetMentorQueryHandler(IMapper mapper, IRepository<Mentor> mentorRepository)
        {
            _mapper = mapper;
            _mentorRepository = mentorRepository;
        }

        public async Task<MentorVm> Handle(GetMentorQuery request, CancellationToken cancellationToken)
        {
            var mentor = await _mentorRepository.GetAsync(request.Id);
            if (mentor == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(mentor), request.Id);
            }
            else
                return _mapper.Map<MentorVm>(mentor);
        }
    }
}
