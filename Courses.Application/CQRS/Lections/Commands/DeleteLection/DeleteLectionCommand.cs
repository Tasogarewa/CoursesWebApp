using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Commands.DeleteLection
{
    public class DeleteLectionCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
