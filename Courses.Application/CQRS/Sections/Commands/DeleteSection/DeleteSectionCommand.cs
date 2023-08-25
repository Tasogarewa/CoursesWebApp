using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
