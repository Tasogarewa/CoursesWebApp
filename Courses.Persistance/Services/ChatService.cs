using AutoMapper;
using Azure.Core;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.UserChats.Commands.CreateChat;
using Tasogarewa.Application.CQRS.UserChats.Commands.DeleteChat;
using Tasogarewa.Application.CQRS.UserChats.Commands.UpdateChat;
using Tasogarewa.Application.CQRS.UserChats.Queries.GetChat;
using Tasogarewa.Application.CQRS.UserChats.Queries.GetChats;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _chatRepository;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public ChatService(IRepository<Chat> chatRepository, IRepository<AppUser> userRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateChatAsync(CreateChatCommand createChat)
        {
            var user = await _userRepository.GetAsync(createChat.UserId);
            NotFoundException<AppUser>.Throw(user, createChat.UserId);
            var chat = await _chatRepository.CreateAsync(new Chat() { Name = createChat.Name, Users = new List<AppUser>() { user, createChat.User } });
            return chat.Id;
        }

        public async Task<Unit> DeleteChatAsync(DeleteChatCommand deleteChat)
        {
            var chat = await _chatRepository.GetAsync(deleteChat.Id);
            NotFoundException<Chat>.Throw(chat, deleteChat.Id);
            await _chatRepository.DeleteAsync(chat);
            return Unit.Value;
        }

        public async Task<ChatVm> GetChatAsync(GetChatQuery getChat)
        {
            var chat = await _chatRepository.GetAsync(getChat.Id);
            NotFoundException<Chat>.Throw( chat, getChat.Id);
            return _mapper.Map<ChatVm>(chat);
        }

        public async Task<ChatListVm> GetChatsAsync(GetChatsQuery getChats)
        {
            var chats =  await _chatRepository.GetAllAsync();
            var user = await _userRepository.GetAsync(getChats.UserId);
            NotFoundException<Chat>.ThrowRange(chats.ToList(), getChats.UserId);
            return new ChatListVm() { chatDtos = _mapper.ProjectTo<ChatDto>(chats.Where(x => x.Users.Contains(user)).AsQueryable()).ToList() };
        }

        public async Task<Guid> UpdateChatAsync(UpdateChatCommand updateChat)
        {
            var chat = await _chatRepository.GetAsync(updateChat.Id);
            NotFoundException<Chat>.Throw(chat, updateChat.Id);
            chat.Name = updateChat.Name;
            await _chatRepository.UpdateAsync(chat);
            return chat.Id;
        }
    }
}
