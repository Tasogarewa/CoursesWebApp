using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Tests.Commands.UpdateTest
{
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, Guid>
    {
      private readonly ITestService _testService;

        public UpdateTestCommandHandler(ITestService testService)
        {
            _testService = testService;
        }

        public async Task<Guid> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            return await _testService.UpdateTestAsync(request);
        }
    }
}
