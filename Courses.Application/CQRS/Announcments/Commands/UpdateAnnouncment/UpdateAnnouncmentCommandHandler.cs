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
        private readonly IRepository<Announcement> _announcmentsRepository;

        public UpdateAnnouncmentCommandHandler(IRepository<Announcement> announcmentsRepository)
        {
            _announcmentsRepository = announcmentsRepository;
        }

        public async Task<Guid> Handle(UpdateAnnouncmentCommand request, CancellationToken cancellationToken)
        {
            var announcment = await _announcmentsRepository.GetAsync(request.Id);
            if(announcment==null||request.MentorId==Guid.Empty||request.CourseId==Guid.Empty)
            {
                throw new NotFoundException(nameof(announcment), request.Id);
            }
            else
            {
                announcment.UpdateAt = DateTime.Now;
                announcment.Images = request.Images;
                announcment.Text = request.Text;
                _announcmentsRepository.Update(announcment);
            }
            return announcment.Id;
        }
    }
}
