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

namespace Tasogarewa.Application.CQRS.CodeExs.Queries.GetCodeEx
{
    public class GetCodeExQueryHandler : IRequestHandler<GetCodeExQuery, CodeExVm>
    {
        private readonly ICodeExService _codeExService;

        public GetCodeExQueryHandler(ICodeExService codeExService)
        {
            _codeExService = codeExService;
        }

        public async Task<CodeExVm> Handle(GetCodeExQuery request, CancellationToken cancellationToken)
        {
          return await _codeExService.GetCodeExAsync(request);
        }
    }
}
