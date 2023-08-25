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
        private readonly IRepository<Announcement> _announcmentsRepository;

        public DeleteAnnouncmentCommandHandler(IRepository<Announcement> announcmentsRepository)
        {
            _announcmentsRepository = announcmentsRepository;
        }

        public async Task<Unit> Handle(DeleteAnnouncmentCommand request, CancellationToken cancellationToken)
        {
            var announcment = await _announcmentsRepository.GetAsync(request.Id);
           if(announcment==null||request.UserId==Guid.Empty)
            {
                throw new NotFoundException(nameof(announcment), request.Id);
              
            }
            else
            {
                _announcmentsRepository.Delete(announcment);
            }
            return Unit.Value;
        }
    }
}
