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
         private readonly IRepository<CodeEx> _codeExRepository;

        public DeleteCodeExCommandHandler(IRepository<CodeEx> codeExRepository)
        {
            _codeExRepository = codeExRepository;
        }

        public async Task<Unit> Handle(DeleteCodeExCommand request, CancellationToken cancellationToken)
        {
            var codeEx = await _codeExRepository.GetAsync(request.Id);
            if(request.Id==Guid.Empty||codeEx==null)
            {
                throw new NotFoundException(nameof(codeEx), request.Id);
            }
            else
            {
                await _codeExRepository.Delete(codeEx);
            }
            return Unit.Value;
        }
    }
}
