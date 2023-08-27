
using MediatR;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.CreateUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.DeleteUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.UpdateUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedLists;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface INamedListService
    {
        public Task<UserNamedListVm> GetNamedListAsync(GetUserNamedListQuery getNamedList);
        public Task<UserNamedListDtoVm> GetNamedListsAsync(GetUserNamedListsQuery getNamedLists);
        public Task<Guid> CreateNamedListAsync(CreateUserNamedListCommand createNamedList);
        public Task<Guid> UpdateNamedListAsync(UpdateUserNamedListCommand updateNamedList);
        public Task<Unit> DeleteNamedListAsync(DeleteUserNamedListCommand deleteNamedList);

    }
}
