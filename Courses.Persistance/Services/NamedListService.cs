using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.CreateUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.DeleteUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Commands.UpdateUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedList;
using Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedLists;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class NamedListService : INamedListService
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<UserNamedList> _userNamedListRepository;
        private readonly IMapper _mapper;

        public NamedListService(IRepository<AppUser> userRepository, IRepository<UserNamedList> userNamedListRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userNamedListRepository = userNamedListRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateNamedListAsync(CreateUserNamedListCommand createNamedList)
        {
            var user = await _userRepository.GetAsync(createNamedList.UserId);
            NotFoundException<AppUser>.Throw(user, createNamedList.UserId);
            var userNamedList = await _userNamedListRepository.CreateAsync(new UserNamedList() { Name = createNamedList.Name, UserNamedCourseList = user.UserNamedCourseList });
            return userNamedList.Id;
        }

        public async Task<Unit> DeleteNamedListAsync(DeleteUserNamedListCommand deleteNamedList)
        {
            var userNamedList = await _userNamedListRepository.GetAsync(deleteNamedList.Id);
            NotFoundException<UserNamedList>.Throw(userNamedList, deleteNamedList.Id);
            await _userNamedListRepository.DeleteAsync(userNamedList);
            return Unit.Value;
        }

        public async Task<UserNamedListVm> GetNamedListAsync(GetUserNamedListQuery getNamedList)
        {
            var userNamedList = await _userNamedListRepository.GetAsync(getNamedList.Id);
            NotFoundException<UserNamedList>.Throw(userNamedList, getNamedList.Id);
            return _mapper.Map<UserNamedListVm>(userNamedList);
        }

        public async Task<UserNamedListDtoVm> GetNamedListsAsync(GetUserNamedListsQuery getNamedLists)
        {
            var userNamedLists = await _userNamedListRepository.GetAllAsync();
            NotFoundException<UserNamedList>.ThrowRange(userNamedLists.ToList(), getNamedLists.UserId);
            var user = await _userRepository.GetAsync(getNamedLists.UserId);
            NotFoundException<AppUser>.Throw(user, getNamedLists.UserId);
            return new UserNamedListDtoVm() { userNamedListDtos =  _mapper.ProjectTo<UserNamedListDto>(userNamedLists.Where(x => x.UserNamedCourseList == user.UserNamedCourseList).AsQueryable()).ToList() };

        }

        public async Task<Guid> UpdateNamedListAsync(UpdateUserNamedListCommand updateNamedList)
        {
            var userNamedList = await _userNamedListRepository.GetAsync(updateNamedList.Id);
            NotFoundException<UserNamedList>.Throw(userNamedList, updateNamedList.Id);
            userNamedList.Name = updateNamedList.Name;
            await _userNamedListRepository.UpdateAsync(userNamedList);
            return userNamedList.Id;
        }
    }
}
