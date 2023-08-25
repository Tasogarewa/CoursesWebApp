using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat
{
    public class UserCourseChatVm : IMapWith<CourseChat>
    {
        public virtual Mentor Mentor { get; set; }
        public string Name { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<AppUser> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CourseChat, UserCourseChatVm>()
                .ForMember(x => x.Mentor, opt => opt.MapFrom(x => x.Mentor))
                 .ForMember(x => x.Course, opt => opt.MapFrom(x => x.Course))
                  .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users))
                   .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                    .ForMember(x => x.Messages, opt => opt.MapFrom(x => x.Messages))
                     .ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images));
        }
    }
}
