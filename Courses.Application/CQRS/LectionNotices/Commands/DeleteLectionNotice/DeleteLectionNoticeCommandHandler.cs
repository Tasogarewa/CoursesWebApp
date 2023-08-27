using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.DeleteLectionNotice
{
    public class DeleteLectionNoticeCommandHandler : IRequestHandler<DeleteLectionNoticeCommand, Unit>
    {
        private readonly ILectionNoticeService _lectionNoticeService;

        public DeleteLectionNoticeCommandHandler(ILectionNoticeService lectionNoticeService)
        {
            _lectionNoticeService = lectionNoticeService;
        }

        public async Task<Unit> Handle(DeleteLectionNoticeCommand request, CancellationToken cancellationToken)
        {
            return await _lectionNoticeService.DeleteLectionNoticeAsync(request);
        }
    }
}
