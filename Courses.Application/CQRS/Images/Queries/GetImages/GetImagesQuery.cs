using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Images.Queries.GetImages
{
    public class GetImagesQuery:IRequest<ImageListVm>
    {
        public Guid CourseId { get; set; }
    }
}
