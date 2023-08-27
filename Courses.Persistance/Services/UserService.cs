using AutoMapper;
using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.AppUsers.Commands.CreateAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Commands.DeleteAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Commands.UpdateAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser;
using Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket;
using Tasogarewa.Application.CQRS.UserArchivedCourses.Queries.GetArchivedCourses;
using Tasogarewa.Application.CQRS.UserLikedCourses.Queries.GetUserLikedCourses;
using Tasogarewa.Application.CQRS.UserNamedCourseLists.Queries.GetUserNamedCoureList;
using Tasogarewa.Application.CQRS.UserWishLists.Queries.GetUserWishList;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Persistance.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<AppUser> userRepository, IRepository<Mentor> mentorRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mentorRepository = mentorRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateUserAsync(CreateAppUserCommand createAppUser)
        {
            var mentor = await _mentorRepository.CreateAsync(new Mentor() { Email = createAppUser.Email, Name = createAppUser.Name, Surname = createAppUser.Surname });
            var user = await _userRepository.CreateAsync(new AppUser() { Email = createAppUser.Email, Name = createAppUser.Name, Surname = createAppUser.Surname, Mentor = mentor, Basket = new Basket(), UserWishList = new UserWishList(), LikedCourses = new LikedCourses(), UserNamedCourseList = new UserNamedCourseList(), ArchivedCourse = new ArchivedCourses() });
            return user.Id;
        }
        public async Task<Unit> DeleteUserAsync(DeleteAppUserCommand deleteAppUser)
        {
            var user = await _userRepository.GetAsync(deleteAppUser.Id);
            NotFoundException<AppUser>.Throw(user, deleteAppUser.Id);
            await _userRepository.DeleteAsync(user);
            return Unit.Value;
        }
        public async Task<ArchivedCourseVm> GetArchivedCoursesAsync(GetArchivedCoursesQuery getArchivedCourses)
        {
            var user = await _userRepository.GetAsync(getArchivedCourses.UserId);
            NotFoundException<AppUser>.Throw(user, getArchivedCourses.UserId);
            return _mapper.Map<ArchivedCourseVm>(user.ArchivedCourse);
        }
        public async Task<BasketVm> GetBasketAsync(GetBasketQuery getBasket)
        {
            var user = await _userRepository.GetAsync(getBasket.UserId);
            NotFoundException<AppUser>.Throw(user, getBasket.UserId);
            return _mapper.Map<BasketVm>(user.Basket);
        }

        public async Task<UserLikedCoursesVm> GetLikedCoursesAsync(GetUserLikedCoursesQuery getLikedCourses)
        {
            var user = await _userRepository.GetAsync(getLikedCourses.UserId);
            NotFoundException<AppUser>.Throw(user, getLikedCourses.UserId);
            return _mapper.Map<UserLikedCoursesVm>(user.LikedCourses);
        }

        public async Task<UserNamedCourseListVm> GetNamedCourseListsAsync(GetUserNamedCourseListQuery getNamedCourseList)
        {
            var user = await _userRepository.GetAsync(getNamedCourseList.UserId);
            NotFoundException<AppUser>.Throw(user, getNamedCourseList.UserId);
            return _mapper.Map<UserNamedCourseListVm>(user.UserNamedCourseList);
        }

        public async Task<AppUserVm> GetUserAsync(GetAppUserQuery getAppUser)
        {
            var user = await _userRepository.GetAsync(getAppUser.Id);
            NotFoundException<AppUser>.Throw(user, getAppUser.Id);
            return _mapper.Map<AppUserVm>(user);
        }

        public async Task<UserWishListVm> GetWishedCoursesAsync(GetUserWishListQuery getWishList)
        {
            var user = await _userRepository.GetAsync(getWishList.UserId);
            NotFoundException<AppUser>.Throw(user, getWishList.UserId);
            return _mapper.Map<UserWishListVm>(user.UserWishList);
        }

        public async Task<Guid> UpdateUserAsync(UpdateAppUserCommand updateAppUser)
        {
            var user = await _userRepository.GetAsync(updateAppUser.Id);
            NotFoundException<AppUser>.Throw(user, updateAppUser.Id);
            user.Surname = updateAppUser.Surname;
            user.Name = updateAppUser.Name;
            user.Email = updateAppUser.Email;
            user.Image = updateAppUser.Image;
            await _userRepository.UpdateAsync(user);
            return user.Id;
        }
    }
}
