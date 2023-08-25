using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSection
{
    public class GetSectionQueryHandler : IRequestHandler<GetSectionQuery, SectionVm>
    {
        private readonly IRepository<Section> _sectionRepository;
        private readonly IMapper _mapper;

        public GetSectionQueryHandler(IRepository<Section> sectionRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _mapper = mapper;
        }

        public async Task<SectionVm> Handle(GetSectionQuery request, CancellationToken cancellationToken)
        {
            var section = _sectionRepository.GetAsync(request.Id);
            if (section == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(section), request.Id);
            }
            else return _mapper.Map<SectionVm>(section);

        }
    }
}
