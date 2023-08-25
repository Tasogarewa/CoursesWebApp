using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.DeleteAppUser
{
    public class DeleteAppUserCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
