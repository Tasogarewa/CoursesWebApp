using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSection
{
    public class GetSectionQuery:IRequest<SectionVm>
    {
        public Guid Id { get; set; }
    }
}
