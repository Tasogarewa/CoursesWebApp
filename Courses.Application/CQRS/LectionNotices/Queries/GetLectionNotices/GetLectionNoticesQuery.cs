using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices
{
    public class GetLectionNoticesQuery:IRequest<LectionNoticeListVm>
    {
        public Guid LectionId { get; set; }
    }
}
