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
        private readonly IMentorService _mentorService;

        public UpdateMentorCommandHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<Guid> Handle(UpdateMentorCommand request, CancellationToken cancellationToken)
        {
            return await _mentorService.UpdateMentorAsync(request);
        }
    }
}
