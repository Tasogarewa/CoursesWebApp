
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
        private readonly IAnnouncmentService _announcmentService;

        public CreateAnnouncmentCommandHandler(IAnnouncmentService announcmentService)
        {
            _announcmentService = announcmentService;
        }

        public async Task<Guid> Handle(CreateAnnouncmentCommand request, CancellationToken cancellationToken)
        {
            return await _announcmentService.CreateAnnouncmentAsync(request);
        }
    }
}
