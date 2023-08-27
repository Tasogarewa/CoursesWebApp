using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Tests.Queries.GetTest
{
    public class GetTestQueryHandler : IRequestHandler<GetTestQuery, TestVm>
    {
        private readonly ITestService _testService;

        public GetTestQueryHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<TestVm> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            return await _testService.GetTestAsync(request);
        }
    }
}
