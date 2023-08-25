using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Commands.UpdateLection
{
    public class UpdateLectionCommandHandler : IRequestHandler<UpdateLectionCommand, Guid>
    {
        private readonly IRepository<Lection> _lectionRepository;

        private readonly IRepository<CodeEx> _codeExRepository;

        private readonly IRepository<Test> _testRepository;

        public UpdateLectionCommandHandler(IRepository<Lection> lectionRepository, IRepository<CodeEx> codeExRepository, IRepository<Test> testRepository)
        {
            _lectionRepository = lectionRepository;
            _codeExRepository = codeExRepository;
            _testRepository = testRepository;
        }

        public async Task<Guid> Handle(UpdateLectionCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetAsync((Guid)request.TestId);
            var codeEx = await _codeExRepository.GetAsync((Guid)request.CodeExId);
            var lection = await _lectionRepository.GetAsync(request.Id);
            if (lection == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(lection),request.Id);
            }
            else
            {
                lection.Description=request.Description;
                lection.FilePath=request.FilePath;
                lection.Name=request.Name;
                lection.CodeEx = codeEx;
                lection.Tests = test;
              await _lectionRepository.Update(lection);
            }
            return lection.Id;
        }
    }
}
