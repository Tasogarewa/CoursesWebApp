using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Queries.GetMentorCourseChats
{
    public class MentorCourseChatDto:IMapWith<CourseChat>
    {
        public virtual Mentor Mentor { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseChat, MentorCourseChatDto>()
                .ForMember(x => x.Mentor, opt => opt.MapFrom(x => x.Mentor))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}
