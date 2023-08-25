using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Tests.Queries.GetTest
{
    public class GetTestQuery:IRequest<TestVm>
    {
        public Guid Id { get; set; }
    }
}
