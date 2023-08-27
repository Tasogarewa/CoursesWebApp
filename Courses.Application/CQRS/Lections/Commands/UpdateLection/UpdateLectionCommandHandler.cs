using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Commands.UpdateLection
{
    public class UpdateLectionCommandHandler : IRequestHandler<UpdateLectionCommand, Guid>
    {
        private readonly ILectionService _lectionService;

        public UpdateLectionCommandHandler(ILectionService lectionService)
        {
            _lectionService = lectionService;
        }

        public async Task<Guid> Handle(UpdateLectionCommand request, CancellationToken cancellationToken)
        {
            return await _lectionService.UpdateLectionAsync(request);
        }
    }
}
