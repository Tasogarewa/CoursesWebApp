using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments
{
    public class GetAnnouncmentsQuery:IRequest<AnnouncmentListVm>
    {
        public Guid CourseId { get; set; }
    }
}
