using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Commands.UpdateImage
{
    public class UpdateImageCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Path { get; set; }
    }
}
