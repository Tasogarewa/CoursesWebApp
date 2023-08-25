using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CodeExs.Commands.CreateCodeEx
{
    public class CreateCodeExCommandHandler : IRequestHandler<CreateCodeExCommand, Guid>
    {
        private readonly IRepository<CodeEx> _codeExRepository;
        private readonly IRepository<Lection> _lectionRepository;

        public CreateCodeExCommandHandler(IRepository<CodeEx> codeExRepository, IRepository<Lection> lectionRepository)
        {
            _codeExRepository = codeExRepository;
            _lectionRepository = lectionRepository;
        }

        public async Task<Guid> Handle(CreateCodeExCommand request, CancellationToken cancellationToken)
        {
            var lection = await _lectionRepository.GetAsync(request.LectionId);
            var codeEx = await _codeExRepository.Create(new CodeEx() { Description = request.Description, Hint = request.Hint, Images = request.Images, Lection = lection, Name = request.Name, Solution = request.Solution });
            return codeEx.Id;
        }
    }
}
