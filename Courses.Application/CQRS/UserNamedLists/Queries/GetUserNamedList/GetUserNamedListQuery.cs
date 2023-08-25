using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedList
{
    public class GetUserNamedListQuery:IRequest<UserNamedListVm>
    {
        public Guid Id { get; set; }
    }
}
