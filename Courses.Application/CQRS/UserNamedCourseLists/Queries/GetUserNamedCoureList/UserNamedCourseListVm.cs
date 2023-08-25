using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserNamedCourseLists.Queries.GetUserNamedCoureList
{
    public class UserNamedCourseListVm:IMapWith<UserNamedCourseList>
    {
        public virtual List<UserNamedList> UserNamedLists { get; set; } = new List<UserNamedList>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserNamedCourseList, UserNamedCourseListVm>()
                .ForMember(x => x.UserNamedLists, opt => opt.MapFrom(x => x.UserNamedLists));
        }
           
    }
}
