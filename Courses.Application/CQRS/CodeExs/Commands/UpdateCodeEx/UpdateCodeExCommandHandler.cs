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
        private readonly IRepository<CodeEx> _codeExRepository;

        public UpdateCodeExCommandHandler(IRepository<CodeEx> codeExRepository)
        {
            _codeExRepository = codeExRepository;
        }

        public async Task<Guid> Handle(UpdateCodeExCommand request, CancellationToken cancellationToken)
        {
            var codeEx = await _codeExRepository.GetAsync(request.Id);
            if (codeEx == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(codeEx), request.Id);
            }
            else
            {
                codeEx.Description = request.Description;
                codeEx.Solution = request.Solution;
                codeEx.Name = request.Name;
                codeEx.Images = request.Images;
                codeEx.Hint = request.Hint;
               await _codeExRepository.Update(codeEx);
            }
            return codeEx.Id;
        }
    }
}
