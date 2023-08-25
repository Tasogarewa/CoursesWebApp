using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.UpdateLectionNotice
{
    public class UpdateLectionNoticeCommandHandler : IRequestHandler<UpdateLectionNoticeCommand, Guid>
    {
         private readonly IRepository<LectionNotice> _lectionNoticeRepository;

        public UpdateLectionNoticeCommandHandler(IRepository<LectionNotice> lectionNoticeRepository)
        {
            _lectionNoticeRepository = lectionNoticeRepository;
        }

        public async Task<Guid> Handle(UpdateLectionNoticeCommand request, CancellationToken cancellationToken)
        {
            var lectionNotice = await _lectionNoticeRepository.GetAsync(request.Id);   
            if (lectionNotice == null||request.Id==Guid.Empty) 
            {
                throw new NotFoundException(nameof(lectionNotice), request.Id);
            }
            else
            {
                lectionNotice.UpdateAt=DateTime.Now;
                lectionNotice.Text = request.Text;
                lectionNotice.From = request.From;
               await _lectionNoticeRepository.Update(lectionNotice); 
            }
            return request.Id;  
        }
    }
}
