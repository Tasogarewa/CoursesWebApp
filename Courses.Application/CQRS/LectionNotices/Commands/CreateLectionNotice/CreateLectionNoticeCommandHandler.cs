using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.CreateLectionNotice
{
    public class CreateLectionNoticeCommandHandler : IRequestHandler<CreateLectionNoticeCommand, Guid>
    {
       private readonly ILectionNoticeService _lectionNoticeService;

        public CreateLectionNoticeCommandHandler(ILectionNoticeService lectionNoticeService)
        {
            _lectionNoticeService = lectionNoticeService;
        }

        public async Task<Guid> Handle(CreateLectionNoticeCommand request, CancellationToken cancellationToken)
        {
            return await _lectionNoticeService.CreateLectionNoticeAsync(request);
        }
    }
}
