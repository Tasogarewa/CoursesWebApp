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
        private readonly IRepository<Test> _testRepository;
        private readonly IMapper _mapper;

        public GetTestQueryHandler(IRepository<Test> testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<TestVm> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetAsync(request.Id);
            if (test == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(test), request.Id);
            }
            else
                return _mapper.Map<TestVm>(test);
        }
    }
}
