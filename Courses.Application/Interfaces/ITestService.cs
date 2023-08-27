
using MediatR;
using Tasogarewa.Application.CQRS.Tests.Commands.CreateTest;
using Tasogarewa.Application.CQRS.Tests.Commands.DeleteTest;
using Tasogarewa.Application.CQRS.Tests.Commands.UpdateTest;
using Tasogarewa.Application.CQRS.Tests.Queries.GetTest;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface ITestService
    {
        public Task<TestVm> GetTestAsync(GetTestQuery getTest);
        public Task<Guid> CreateTestAsync(CreateTestCommand createTest);
        public Task<Guid> UpdateTestAsync(UpdateTestCommand updateTest);
        public Task<Unit> DeleteTestAsync(DeleteTestCommand deleteTest);

    }
}
