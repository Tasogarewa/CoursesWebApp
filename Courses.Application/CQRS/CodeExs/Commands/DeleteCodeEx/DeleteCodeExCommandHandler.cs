using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CodeExs.Commands.DeleteCodeEx
{
    public class DeleteCodeExCommandHandler : IRequestHandler<DeleteCodeExCommand, Unit>
    {
        private readonly ICodeExService _codeExService;

        public DeleteCodeExCommandHandler(ICodeExService codeExService)
        {
            _codeExService = codeExService;
        }

        public async Task<Unit> Handle(DeleteCodeExCommand request, CancellationToken cancellationToken)
        {
            return await _codeExService.DeleteCodeExAsync(request);
        }
    }
}
