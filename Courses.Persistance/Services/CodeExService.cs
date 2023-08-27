using AutoMapper;
using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.CodeExs.Commands.CreateCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Commands.DeleteCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Commands.UpdateCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Queries.GetCodeEx;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class CodeExService : ICodeExService
    {
        private readonly IRepository<Lection> _lectionRepository;
        private readonly IRepository<CodeEx> _codeExRepository;
        private readonly IMapper _mapper;

        public CodeExService(IRepository<Lection> lectionRepository, IRepository<CodeEx> codeExRepository, IMapper mapper)
        {
            _lectionRepository = lectionRepository;
            _codeExRepository = codeExRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCodeExAsync(CreateCodeExCommand createCodeEx)
        {
            var lection = await _lectionRepository.GetAsync(createCodeEx.LectionId);
            NotFoundException<Lection>.Throw(lection, createCodeEx.LectionId);
            var  codeEx = await _codeExRepository.CreateAsync(new CodeEx() { Description = createCodeEx.Description, Hint = createCodeEx.Hint, Images = createCodeEx.Images, Lection = lection, Name = createCodeEx.Name, Solution = createCodeEx.Solution });
            return codeEx.Id;
        }
        public async Task<Unit> DeleteCodeExAsync(DeleteCodeExCommand deleteCodeEx)
        {
            var codeEx = await _codeExRepository.GetAsync(deleteCodeEx.Id);
            NotFoundException<CodeEx>.Throw(codeEx, deleteCodeEx.Id);
            await _codeExRepository.DeleteAsync(codeEx);
            return Unit.Value;
        }
        public async Task<CodeExVm> GetCodeExAsync(GetCodeExQuery getCodeEx)
        {
            var codeEx = await _codeExRepository.GetAsync(getCodeEx.Id);
            NotFoundException<CodeEx>.Throw(codeEx, getCodeEx.Id);
            return _mapper.Map<CodeExVm>(codeEx);
        }

        public async Task<Guid> UpdateCodeExAsync(UpdateCodeExCommand updateCodeEx)
        {
            var codeEx = await _codeExRepository.GetAsync(updateCodeEx.Id);
            NotFoundException<CodeEx>.Throw(codeEx, updateCodeEx.Id);
            codeEx.Description = updateCodeEx.Description;
            codeEx.Solution = updateCodeEx.Solution;
            codeEx.Name = updateCodeEx.Name;
            codeEx.Images = updateCodeEx.Images;
            codeEx.Hint = updateCodeEx.Hint;
            await _codeExRepository.UpdateAsync(codeEx);
            return codeEx.Id;
        }
    }
}
