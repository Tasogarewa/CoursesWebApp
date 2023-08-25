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
        private readonly IMapper _mapper;
        private readonly IRepository<CodeEx> _codeExRepository;

        public GetCodeExQueryHandler(IMapper mapper, IRepository<CodeEx> codeExRepository)
        {
            _mapper = mapper;
            _codeExRepository = codeExRepository;
        }

        public async Task<CodeExVm> Handle(GetCodeExQuery request, CancellationToken cancellationToken)
        {
            var codeEx = await _codeExRepository.GetAsync(request.Id);
            if(request.Id==Guid.Empty||codeEx==null)
            {
                throw new NotFoundException(nameof(codeEx), request.Id);
            }
             else
                return _mapper.Map<CodeExVm>(codeEx); 
        }
    }
}
