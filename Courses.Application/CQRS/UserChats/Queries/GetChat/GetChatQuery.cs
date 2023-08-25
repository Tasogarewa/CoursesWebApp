using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserChats.Queries.GetChat
{
    public class GetChatQuery:IRequest<ChatVm>
    {
        public Guid Id { get; set; }
    }
}
