using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLection
{
    public class GetLectionQuery:IRequest<LectionVm>
    {
        public Guid Id { get; set; }
    }
}
