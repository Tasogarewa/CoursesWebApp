using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChat
{
    public class GetChatQuery:IRequest<ChatVm>
    {
        public Guid Id  { get; set;}
    }
}
