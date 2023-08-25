using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Commands.CreateLection
{
    public class CreateLectionCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid SectionId { get; set; }
    }
}
