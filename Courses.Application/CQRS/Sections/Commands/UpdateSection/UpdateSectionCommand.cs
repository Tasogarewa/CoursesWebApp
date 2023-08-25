using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Lection>? Lections { get; set; } = new List<Lection>();
    }
}
