
using Tasogarewa.Application.CQRS.Mentors.Commands.UpdateMentor;
using Tasogarewa.Application.CQRS.Mentors.Queries.GetMentor;
using Tasogarewa.Application.CQRS.Mentors.Queries.GetMentors;

namespace Tasogarewa.Application.Interfaces
{
    public interface IMentorService
    {
        public Task<MentorVm> GetMentorAsync(GetMentorQuery getMentor);
        public Task<MentorListVm> GetMentorsAsync();
        public Task<Guid> UpdateMentorAsync(UpdateMentorCommand updateMentor);
    }
}
