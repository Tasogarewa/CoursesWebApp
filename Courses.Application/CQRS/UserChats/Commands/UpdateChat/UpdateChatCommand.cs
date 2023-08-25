using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.UpdateChat
{
    public class UpdateChatCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
