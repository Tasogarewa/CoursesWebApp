using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, Guid>
    {
        private readonly IRepository<Section> _sectionRepository;

        public UpdateSectionCommandHandler(IRepository<Section> sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<Guid> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _sectionRepository.GetAsync(request.Id);
            if (section == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(section),request.Id);
            }
            else
            {
                section.Lections = request.Lections;
                section.Name = request.Name;
               await _sectionRepository.Update(section);
            }
            return section.Id;

        }
    }
}
