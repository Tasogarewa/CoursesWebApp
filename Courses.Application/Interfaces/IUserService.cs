using MediatR;
using Tasogarewa.Application.CQRS.AppUsers.Commands.CreateAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Commands.DeleteAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Commands.UpdateAppUser;
using Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser;
using Tasogarewa.Application.CQRS.Baskets.Queries.GetBasket;
using Tasogarewa.Application.CQRS.UserArchivedCourses.Queries.GetArchivedCourses;
using Tasogarewa.Application.CQRS.UserLikedCourses.Queries.GetUserLikedCourses;
using Tasogarewa.Application.CQRS.UserNamedCourseLists.Queries.GetUserNamedCoureList;
using Tasogarewa.Application.CQRS.UserWishLists.Queries.GetUserWishList;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.Interfaces
{
    public interface IUserService
    {
        public Task<AppUserVm> GetUserAsync(GetAppUserQuery getAppUser);
        public Task<Guid> CreateUserAsync(CreateAppUserCommand createAppUser);
        public Task<Guid> UpdateUserAsync(UpdateAppUserCommand updateAppUser);
        public Task<Unit> DeleteUserAsync(DeleteAppUserCommand deleteAppUser);

        public Task<BasketVm> GetBasketAsync(GetBasketQuery getBasket);

        public Task<ArchivedCourseVm> GetArchivedCoursesAsync(GetArchivedCoursesQuery getArchivedCourses);

        public Task<UserLikedCoursesVm> GetLikedCoursesAsync(GetUserLikedCoursesQuery getLikedCourses);

        public Task<UserNamedCourseListVm> GetNamedCourseListsAsync(GetUserNamedCourseListQuery getNamedCourseList);

        public Task<UserWishListVm> GetWishedCoursesAsync(GetUserWishListQuery getWishList);
    }
}
