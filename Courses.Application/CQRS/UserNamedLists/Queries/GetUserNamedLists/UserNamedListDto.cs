using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedList;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedLists
{
    public class UserNamedListDto:IMapWith<UserNamedList>
    {
        public string Name { get; set; }
        public List<InListCourse> InListCourses { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserNamedList, UserNamedListVm>()
                .ForMember(x => x.InListCourses, opt => opt.MapFrom(x => x.InListCourses))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}
