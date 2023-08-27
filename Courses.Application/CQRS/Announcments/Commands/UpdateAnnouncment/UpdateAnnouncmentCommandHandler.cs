using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.UpdateAnnouncments
{
    public class UpdateAnnouncmentCommandHandler : IRequestHandler<UpdateAnnouncmentCommand, Guid>
    {
        private readonly IAnnouncmentService _announcmentService;

        public UpdateAnnouncmentCommandHandler(IAnnouncmentService announcmentService)
        {
            _announcmentService = announcmentService;
        }

        public async Task<Guid> Handle(UpdateAnnouncmentCommand request, CancellationToken cancellationToken)
        {
           return await _announcmentService.UpdateAnnoucmentAsync(request);
        }
    }
}
