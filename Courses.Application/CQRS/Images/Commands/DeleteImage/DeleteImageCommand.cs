using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Commands.DeleteImage
{
    public class DeleteImageCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
