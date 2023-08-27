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
        private readonly ILectionNoticeService _lectionNoticeService;

        public UpdateLectionNoticeCommandHandler(ILectionNoticeService lectionNoticeService)
        {
            _lectionNoticeService = lectionNoticeService;
        }

        public async Task<Guid> Handle(UpdateLectionNoticeCommand request, CancellationToken cancellationToken)
        {
            return await _lectionNoticeService.UpdateLectionNoticeAsync(request);
        }
    }
}
