using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Unit>
    {
        private readonly IRepository<Section> _sectionRepository;

        public DeleteSectionCommandHandler(IRepository<Section> sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<Unit> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _sectionRepository.GetAsync(request.Id);
            if (section == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(section), request.Id);
            }
            else
                 await _sectionRepository.Delete(section);
                return Unit.Value;
        }
    }
}
