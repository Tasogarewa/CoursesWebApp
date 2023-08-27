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
        private readonly IMentorService _mentorService;

        public GetMentorsQueryHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<MentorListVm> Handle(GetMentorsQuery request, CancellationToken cancellationToken)
        {
            return await _mentorService.GetMentorsAsync();
        }
    }
}
