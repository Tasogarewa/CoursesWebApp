using AutoMapper;
using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Tests.Commands.CreateTest;
using Tasogarewa.Application.CQRS.Tests.Commands.DeleteTest;
using Tasogarewa.Application.CQRS.Tests.Commands.UpdateTest;
using Tasogarewa.Application.CQRS.Tests.Queries.GetTest;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class TestService : ITestService
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<Lection> _lectionRepository;
        private readonly IMapper _mapper;

        public TestService(IRepository<Test> testRepository, IRepository<Lection> lectionRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _lectionRepository = lectionRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateTestAsync(CreateTestCommand createTest)
        {
            var test = await _testRepository.CreateAsync(new Test() { Lection = await _lectionRepository.GetAsync(createTest.LectionId), Description = createTest.Description, Name = createTest.Name, Questions = createTest.Questions });
            return test.Id;
        }
        public async Task<Unit> DeleteTestAsync(DeleteTestCommand deleteTest)
        {
            var test = await _testRepository.GetAsync(deleteTest.Id);
            NotFoundException<Test>.Throw(test, deleteTest.Id);
            await _testRepository.DeleteAsync(test);
            return Unit.Value;
        }
        public async Task<TestVm> GetTestAsync(GetTestQuery getTest)
        {
           var test = await _testRepository.GetAsync(getTest.Id);
            NotFoundException<Test>.Throw(test, getTest.Id);
            return _mapper.Map<TestVm>(test);
        }

        public async Task<Guid> UpdateTestAsync(UpdateTestCommand updateTest)
        {
            var test = await _testRepository.GetAsync(updateTest.Id);
            NotFoundException<Test>.Throw(test, updateTest.Id);
            test.Description = updateTest.Description;
            test.Questions = updateTest.Questions;
            test.Name = updateTest.Name;
            await _testRepository.UpdateAsync(test);
            return test.Id;
        }
    }
}
