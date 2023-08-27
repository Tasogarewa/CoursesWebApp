using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLections
{
    public class GetLectionsQuery:IRequest<LectionListVm>
    {
        public Guid SectionId { get; set; }
    }
}
