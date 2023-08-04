using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Commands.CreateImage
{
    public class CreateImageCommand:IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Guid? CourseId { get; set; }
        public string Path { get; set; }
    }
}
