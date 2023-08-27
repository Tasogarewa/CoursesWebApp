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
        private readonly ILectionNoticeService _lectionNoticeService;

        public GetLectionNoticesQueryHandler(ILectionNoticeService lectionNoticeService)
        {
            _lectionNoticeService = lectionNoticeService;
        }

        public async Task<LectionNoticeListVm> Handle(GetLectionNoticesQuery request, CancellationToken cancellationToken)
        {
            return await _lectionNoticeService.GetLectionNoticesAsync(request);
        }
    }
}
