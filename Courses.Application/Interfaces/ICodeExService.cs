using MediatR;
using System;
using Tasogarewa.Application.CQRS.CodeExs.Commands.CreateCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Commands.DeleteCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Commands.UpdateCodeEx;
using Tasogarewa.Application.CQRS.CodeExs.Queries.GetCodeEx;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface ICodeExService
    {
        public Task<CodeExVm> GetCodeExAsync(GetCodeExQuery getCodeEx);
        public Task<Guid> CreateCodeExAsync(CreateCodeExCommand createCodeEx);
        public Task<Guid> UpdateCodeExAsync(UpdateCodeExCommand updateCodeEx);
        public Task<Unit> DeleteCodeExAsync(DeleteCodeExCommand deleteCodeEx);
    }
}
