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
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments
{
    public class GetAnnouncmentsQueryHandler : IRequestHandler<GetAnnouncmentsQuery, AnnouncmentListVm>
    {
        private readonly IAnnouncmentService _announcmentService;

        public GetAnnouncmentsQueryHandler(IAnnouncmentService announcmentService)
        {
            _announcmentService = announcmentService;
        }

        public async Task<AnnouncmentListVm> Handle(GetAnnouncmentsQuery request, CancellationToken cancellationToken)
        {
          return await _announcmentService.GetAnnouncmentsAsync(request);
        }
    }
}
