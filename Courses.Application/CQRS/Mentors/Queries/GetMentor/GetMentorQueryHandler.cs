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
        private readonly IMentorService _mentorService;

        public GetMentorQueryHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<MentorVm> Handle(GetMentorQuery request, CancellationToken cancellationToken)
        {
            return await _mentorService.GetMentorAsync(request);
        }
    }
}
