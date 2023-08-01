using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.CQRS.Chats.Queries.GetChats;

namespace Tasogarewa.Application.CQRS.Comments.Queries.GetComments
{
    public class CommentListVm
    {
        public List<CommentsDto> CommentsList { get; set; }
    }
}
