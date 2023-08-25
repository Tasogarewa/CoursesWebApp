using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Comments.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
