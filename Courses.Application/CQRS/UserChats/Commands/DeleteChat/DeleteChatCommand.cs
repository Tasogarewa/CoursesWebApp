using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.DeleteChat
{
    public class DeleteChatCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
