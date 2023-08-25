using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSections
{
    public class GetSectionsQuery : IRequest<SectionListVm>
    {
        public Guid CourseId { get; set; }
    }
}
