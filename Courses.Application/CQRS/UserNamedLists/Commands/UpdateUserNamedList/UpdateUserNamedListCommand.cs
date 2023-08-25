using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.UpdateUserNamedList
{
    public class UpdateUserNamedListCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
