using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser
{
    public class GetAppUserQuery:IRequest<AppUserVm>
    {
        public Guid Id { get; set; }
    }
}
