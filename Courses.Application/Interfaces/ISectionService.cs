
using MediatR;
using Tasogarewa.Application.CQRS.Sections.Commands.CreateSection;
using Tasogarewa.Application.CQRS.Sections.Commands.DeleteSection;
using Tasogarewa.Application.CQRS.Sections.Commands.UpdateSection;
using Tasogarewa.Application.CQRS.Sections.Queries.GetSection;
using Tasogarewa.Application.CQRS.Sections.Queries.GetSections;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface ISectionService
    {
        public Task<SectionVm> GetSectionAsync(GetSectionQuery getSection);
        public Task<SectionListVm> GetSectionsAsync(GetSectionsQuery getSections);
        public Task<Guid> CreateSectionAsync(CreateSectionCommand createSection);
        public Task<Guid> UpdateSectionAsync(UpdateSectionCommand updateSection);
        public Task<Unit> DeleteSectionAsync(DeleteSectionCommand deleteSection);
    }
}
