using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChats
{
    public class GetChatsQuery : IRequest<ChatsListVm>
    {
       public Guid UserId { get; set; }
    }
}
