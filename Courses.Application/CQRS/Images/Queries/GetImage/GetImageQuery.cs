using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImage
{
    public class GetImageQuery:IRequest<ImageVm>
    {
        public Guid Id { get; set; }
    }
}
