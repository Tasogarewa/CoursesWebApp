using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.DeleteAnnouncments
{
    public class DeleteAnnouncmentCommandHandler:IRequestHandler<DeleteAnnouncmentCommand,Unit>
    {
        private readonly IAnnouncmentService _announcmentService;

        public DeleteAnnouncmentCommandHandler(IAnnouncmentService announcmentService)
        {
            _announcmentService = announcmentService;
        }

        public async Task<Unit> Handle(DeleteAnnouncmentCommand request, CancellationToken cancellationToken)
        {
            return await _announcmentService.DeleteAnnouncmentAsync(request);
        }
    }
}
