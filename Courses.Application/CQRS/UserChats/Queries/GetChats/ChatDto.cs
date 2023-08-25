using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserChats.Queries.GetChats
{
    public class ChatDto:IMapWith<Chat>
    {
        public string Name { get; set; }
         public List<AppUser> Users { get; set; } = new List<AppUser>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chat, ChatDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                 .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users));
        }
    }
}
