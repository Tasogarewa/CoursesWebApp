using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Commands.CreateLection
{
    public class CreateLectionCommandHandler : IRequestHandler<CreateLectionCommand, Guid>
    {
       private readonly ILectionService _lectionService;

        public CreateLectionCommandHandler(ILectionService lectionService)
        {
            _lectionService = lectionService;
        }

        public async Task<Guid> Handle(CreateLectionCommand request, CancellationToken cancellationToken)
        {
            return await _lectionService.CreateLectionAsync(request);
        }
    }
}
