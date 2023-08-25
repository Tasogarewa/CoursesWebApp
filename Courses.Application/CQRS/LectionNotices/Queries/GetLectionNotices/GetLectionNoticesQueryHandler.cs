using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices
{
    public class GetLectionNoticesQueryHandler : IRequestHandler<GetLectionNoticesQuery, LectionNoticeListVm>
    {
        private readonly IRepository<Lection> _lectionRepository;
        private readonly IMapper _mapper;

        public GetLectionNoticesQueryHandler(IRepository<Lection> lectionRepository, IMapper mapper)
        {
            _lectionRepository = lectionRepository;
            _mapper = mapper;
        }

        public async Task<LectionNoticeListVm> Handle(GetLectionNoticesQuery request, CancellationToken cancellationToken)
        {
            var lection = await _lectionRepository.GetAsync(request.LectionId);
            if (lection == null || request.LectionId == Guid.Empty)
            {
                throw new NotFoundException(nameof(lection), request.LectionId);
            }
            else
                return new LectionNoticeListVm() { lectionNoticeDtos = await _mapper.ProjectTo<LectionNoticeDto>((IQueryable)lection.LectionNotices).ToListAsync() };
        }
    }
}
