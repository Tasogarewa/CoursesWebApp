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
        private readonly ICodeExService _codeExService;

        public CreateCodeExCommandHandler(ICodeExService codeExService)
        {
            _codeExService = codeExService;
        }
        public async Task<Guid> Handle(CreateCodeExCommand request, CancellationToken cancellationToken)
        {
            return await _codeExService.CreateCodeExAsync(request);
        }
    }
}
