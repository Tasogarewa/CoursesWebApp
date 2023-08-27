using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Commands.CreateSection
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Guid>
    {
        private readonly ISectionService _sectionService;

        public CreateSectionCommandHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<Guid> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            return await _sectionService.CreateSectionAsync(request);
        }
    }
}
