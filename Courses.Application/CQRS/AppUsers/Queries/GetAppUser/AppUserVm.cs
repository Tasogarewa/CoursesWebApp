using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser
{
    public class AppUserVm:IMapWith<AppUser>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual Image Image { get; set; }
        public string Email { get; set; }
        public List<CourseStudent> Courses { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, AppUserVm>()
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.Surname))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Image))
               .ForMember(x => x.Courses, opt => opt.MapFrom(x => x.Courses));
        }
    }
}
