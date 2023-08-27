using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CodeExs.Commands.UpdateCodeEx
{
    public class UpdateCodeExCommandHandler : IRequestHandler<UpdateCodeExCommand, Guid>
    {
        private readonly ICodeExService _codeExService;

        public UpdateCodeExCommandHandler(ICodeExService codeExService)
        {
            _codeExService = codeExService;
        }

        public async Task<Guid> Handle(UpdateCodeExCommand request, CancellationToken cancellationToken)
        {
           return await _codeExService.UpdateCodeExAsync(request);
        }
    }
}
