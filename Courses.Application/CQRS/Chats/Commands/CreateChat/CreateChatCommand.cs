using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Chats.Commands.CreateChat
{
    public class CreateChatCommand : IRequest<Guid>
    {
   
        public ICollection<AppUser> Users { get; set; }
       
    }
}
