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
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Lection> _lectionRepository;

        public CreateTestCommandHandler(IRepository<Test> testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<Guid> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.Create(new Test() { Lection = await _lectionRepository.GetAsync(request.LectionId),Description = request.Description, Name = request.Name, Questions = request.Questions });
            return test.Id;
        }
    }
}
