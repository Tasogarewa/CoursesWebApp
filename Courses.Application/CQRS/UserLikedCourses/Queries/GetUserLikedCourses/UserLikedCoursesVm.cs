using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserLikedCourses.Queries.GetUserLikedCourses
{
    public class UserLikedCoursesVm:IMapWith<LikedCourses>
    {
        public virtual List<LikedCourse> Courses { get; set; } = new List<LikedCourse>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LikedCourses, UserLikedCoursesVm>()
                .ForMember(x => x.Courses, opt => opt.MapFrom(x => x.Courses));
        }
    }
}
