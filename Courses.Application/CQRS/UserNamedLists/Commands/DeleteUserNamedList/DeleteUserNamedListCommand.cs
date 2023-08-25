using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.DeleteUserNamedList
{
    public class DeleteUserNamedListCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
