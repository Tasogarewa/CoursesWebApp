using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CodeExs.Queries.GetCodeEx
{
    public class GetCodeExQuery:IRequest<CodeExVm>
    {
        public Guid Id { get; set; }
    }
}
