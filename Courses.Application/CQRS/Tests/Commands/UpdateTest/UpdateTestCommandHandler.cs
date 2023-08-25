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
        private readonly IRepository<Test> _testRepository;

        public UpdateTestCommandHandler(IRepository<Test> testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<Guid> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetAsync(request.Id);
            if (test == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(test),request.Id);
            }
            else
            {
                test.Description=request.Description;
                test.Questions=request.Questions;
                test.Name= request.Name;
                await _testRepository.Update(test);
            }
            return test.Id;
        }
    }
}
