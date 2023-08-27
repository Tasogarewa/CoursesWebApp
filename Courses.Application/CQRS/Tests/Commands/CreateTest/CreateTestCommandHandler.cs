using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Tests.Commands.CreateTest
{
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, Guid>
    {
        private readonly ITestService _testService;

        public CreateTestCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<Guid> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            return await _testService.CreateTestAsync(request);
        }
    }
}
