using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Comments.Queries.GetComments
{
    public class GetCommentsQuery:IRequest<CommentListVm>
    {
       

        public Guid CourseId { get; set; }
    }
}
