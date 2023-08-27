using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedLists
{
    public class GetUserNamedListsQuery:IRequest<UserNamedListDtoVm>
    {
        public Guid UserId { get; set; }
    }
}
