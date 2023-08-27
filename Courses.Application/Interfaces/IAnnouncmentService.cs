
using MediatR;
using Tasogarewa.Application.CQRS.Announcments.Commands.CreateAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Commands.DeleteAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Commands.UpdateAnnouncments;
using Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface IAnnouncmentService
    {
        public Task<AnnouncmentListVm> GetAnnouncmentsAsync(GetAnnouncmentsQuery announcmentsQuery);
        public Task<Guid> CreateAnnouncmentAsync(CreateAnnouncmentCommand announcementCreate);
        public Task<Guid> UpdateAnnoucmentAsync(UpdateAnnouncmentCommand announcementUpdate);
        public Task<Unit> DeleteAnnouncmentAsync(DeleteAnnouncmentCommand deleteAnnouncmentCommand);

    }
}
