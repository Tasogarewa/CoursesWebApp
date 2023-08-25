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
        private readonly IRepository<Lection> _lectionRepository;
        private readonly IMapper _mapper;

        public GetLectionQueryHandler(IRepository<Lection> lectionRepository, IMapper mapper)
        {
            _lectionRepository = lectionRepository;
            _mapper = mapper;
        }

        public async Task<LectionVm> Handle(GetLectionQuery request, CancellationToken cancellationToken)
        {
            var lection = await _lectionRepository.GetAsync(request.Id);
            if (lection == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(lection), request.Id);
            }
            else
                return _mapper.Map<LectionVm>(lection);
        }
    }
}
