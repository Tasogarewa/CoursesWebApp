using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLections
{
    public class GetLectionQueryHandler : IRequestHandler<GetLectionsQuery, LectionListVm>
    {
        private readonly ILectionService _lectionService;

        public GetLectionQueryHandler(ILectionService lectionService)
        {
            _lectionService = lectionService;
        }

        public async Task<LectionListVm> Handle(GetLectionsQuery request, CancellationToken cancellationToken)
        {
            return await _lectionService.GetLectionsAsync(request);
        }
    }
}
