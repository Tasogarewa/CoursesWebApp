
using MediatR;
using Tasogarewa.Application.CQRS.Lections.Commands.CreateLection;
using Tasogarewa.Application.CQRS.Lections.Commands.DeleteLection;
using Tasogarewa.Application.CQRS.Lections.Commands.UpdateLection;
using Tasogarewa.Application.CQRS.Lections.Queries.GetLection;
using Tasogarewa.Application.CQRS.Lections.Queries.GetLections;

namespace Tasogarewa.Application.Interfaces
{
    public interface ILectionService
    {
        public Task<LectionVm> GetLectionAsync(GetLectionQuery getLection);
        public Task<LectionListVm> GetLectionsAsync(GetLectionsQuery getLections);
        public Task<Guid> CreateLectionAsync(CreateLectionCommand createLection);
        public Task<Guid> UpdateLectionAsync(UpdateLectionCommand updateLection);
        public Task<Unit> DeleteLectionAsync(DeleteLectionCommand deleteLection);
    }
}
