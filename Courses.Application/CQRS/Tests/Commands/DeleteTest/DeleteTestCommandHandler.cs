using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Tests.Commands.DeleteTest
{
    public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand, Unit>
    {
        private readonly IRepository<Test> _testRepository;

        public DeleteTestCommandHandler(IRepository<Test> testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<Unit> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetAsync(request.Id);
            if (test == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(test),request.Id);
            }
            else
               await _testRepository.Delete(test);
            return Unit.Value;
        }
    }
}
