using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.DeleteLectionNotice
{
    public class DeleteLectionNoticeCommandHandler : IRequestHandler<DeleteLectionNoticeCommand, Unit>
    {
        private readonly IRepository<LectionNotice> _lectionNoticeRepository;

        public DeleteLectionNoticeCommandHandler(IRepository<LectionNotice> lectionNoticeRepository)
        {
            _lectionNoticeRepository = lectionNoticeRepository;
        }

        public async Task<Unit> Handle(DeleteLectionNoticeCommand request, CancellationToken cancellationToken)
        {
            var lectionNotice = await _lectionNoticeRepository.GetAsync(request.Id);
            if (lectionNotice == null||request.Id==Guid.Empty) 
            {
                throw new NotFoundException(nameof(lectionNotice), request.Id);
            }
            else
            {
               await _lectionNoticeRepository.Delete(lectionNotice);
                return Unit.Value;
            }
        }
    }
}
