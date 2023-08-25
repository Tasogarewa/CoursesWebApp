using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserWishLists.Queries.GetUserWishList
{
    public class UserWishListVm:IMapWith<UserWishList>
    {
        public  List<UserWishedCourse> WishedCourses { get; set; } = new List<UserWishedCourse>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserWishList, UserWishListVm>()
                .ForMember(x => x.WishedCourses, opt => opt.MapFrom(x => x.WishedCourses));
        }
    }
}
