using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSections
{
    public class GetSectionsQueryHandler : IRequestHandler<GetSectionsQuery, SectionListVm>
    {
        private readonly ISectionService _sectionService;

        public GetSectionsQueryHandler(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        public async Task<SectionListVm> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
        {
            return await _sectionService.GetSectionsAsync(request);
        }
    }
}
