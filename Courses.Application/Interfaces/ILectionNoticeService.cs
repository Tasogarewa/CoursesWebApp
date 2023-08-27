using MediatR;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.CreateLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.DeleteLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Commands.UpdateLectionNotice;
using Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices;

namespace Tasogarewa.Application.Interfaces
{
    public interface ILectionNoticeService
    { 
        public Task<LectionNoticeListVm> GetLectionNoticesAsync(GetLectionNoticesQuery getLectionNotices);
        public Task<Guid> CreateLectionNoticeAsync(CreateLectionNoticeCommand createLectionNotice);
        public Task<Guid> UpdateLectionNoticeAsync(UpdateLectionNoticeCommand updateLectionNotice);
        public Task<Unit> DeleteLectionNoticeAsync(DeleteLectionNoticeCommand deleteLectionNotice);
    }
}
