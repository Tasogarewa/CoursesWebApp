using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.CreateUserNamedList
{
    public class CreateUserNamedListCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
