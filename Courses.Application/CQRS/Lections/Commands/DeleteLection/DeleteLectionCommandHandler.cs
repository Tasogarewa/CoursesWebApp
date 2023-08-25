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
        private readonly IRepository<Lection> _lectionRepository;

        public DeleteLectionCommandHandler(IRepository<Lection> lectionRepository)
        {
            _lectionRepository = lectionRepository;
        }

        public async Task<Unit> Handle(DeleteLectionCommand request, CancellationToken cancellationToken)
        {
            var lection = await _lectionRepository.GetAsync(request.Id);
            if (lection == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(lection), request.Id);
            }
            else
               await _lectionRepository.Delete(lection);
            return Unit.Value;
        }
    }
}
