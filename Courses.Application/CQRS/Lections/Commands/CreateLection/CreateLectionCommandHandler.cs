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
        private readonly IRepository<Section> _sectionRepository;
        private readonly IRepository<Lection> _lectionRepository;

        public CreateLectionCommandHandler(IRepository<Section> sectionRepository, IRepository<Lection> lectionRepository)
        {
            _sectionRepository = sectionRepository;
            _lectionRepository = lectionRepository;
        }

        public async Task<Guid> Handle(CreateLectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _sectionRepository.GetAsync(request.SectionId);
            var lection = await _lectionRepository.Create(new Lection() { Name = request.Name, Section = section });
            return lection.Id;
        }
    }
}
