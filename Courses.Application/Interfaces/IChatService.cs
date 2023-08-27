using MediatR;
using Tasogarewa.Application.CQRS.UserChats.Commands.CreateChat;
using Tasogarewa.Application.CQRS.UserChats.Commands.DeleteChat;
using Tasogarewa.Application.CQRS.UserChats.Commands.UpdateChat;
using Tasogarewa.Application.CQRS.UserChats.Queries.GetChat;
using Tasogarewa.Application.CQRS.UserChats.Queries.GetChats;

namespace Tasogarewa.Application.Interfaces
{
    public interface IChatService
    {
        public Task<ChatVm> GetChatAsync(GetChatQuery getChat);
        public Task<ChatListVm> GetChatsAsync(GetChatsQuery getChats);
        public Task<Guid> CreateChatAsync(CreateChatCommand createChat);
        public Task<Guid> UpdateChatAsync(UpdateChatCommand updateChat);
        public Task<Unit> DeleteChatAsync(DeleteChatCommand deleteChat);
    }
}
