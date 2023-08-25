using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Commands.CreateSection
{
    public class CreateSectionCommand:IRequest<Guid>
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
    }
}
