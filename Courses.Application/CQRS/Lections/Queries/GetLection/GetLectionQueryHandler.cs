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

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLection
{
    public class GetLectionQueryHandler : IRequestHandler<GetLectionQuery, LectionVm>
    {
        private readonly ILectionService _lectionService;

        public GetLectionQueryHandler(ILectionService lectionService)
        {
            _lectionService = lectionService;
        }

        public async Task<LectionVm> Handle(GetLectionQuery request, CancellationToken cancellationToken)
        {
            return await _lectionService.GetLectionAsync(request);
        }
    }
}
