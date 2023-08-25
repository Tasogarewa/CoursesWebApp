using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CodeExs.Commands.DeleteCodeEx
{
    public class DeleteCodeExCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
