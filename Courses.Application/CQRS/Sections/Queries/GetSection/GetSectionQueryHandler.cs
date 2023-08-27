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
        private readonly ISectionService _sectionService;

        public GetSectionQueryHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<SectionVm> Handle(GetSectionQuery request, CancellationToken cancellationToken)
        {
            return await _sectionService.GetSectionAsync(request);

        }
    }
}
