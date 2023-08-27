using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Commands.DeleteLection
{
    public class DeleteLectionCommandHandler : IRequestHandler<DeleteLectionCommand, Unit>
    {
        private readonly ILectionService _lectionService;

        public DeleteLectionCommandHandler(ILectionService lectionService)
        {
            _lectionService = lectionService;
        }

        public async Task<Unit> Handle(DeleteLectionCommand request, CancellationToken cancellationToken)
        {
            return await _lectionService.DeleteLectionAsync(request);
        }
    }
}
