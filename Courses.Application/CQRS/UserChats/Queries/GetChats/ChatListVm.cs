using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserChats.Queries.GetChats
{
    public class ChatListVm
    {
        public List<ChatDto> chatDtos { get; set; }
    }
}
