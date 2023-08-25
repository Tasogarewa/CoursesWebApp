using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Commands.UpdateLection
{
    public class UpdateLectionCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public Guid? TestId { get; set; }
        public Guid? CodeExId  { get; set; }
    }
}
