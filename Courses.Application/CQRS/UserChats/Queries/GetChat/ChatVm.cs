using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserChats.Queries.GetChat
{
    public class ChatVm:IMapWith<Chat>
    {
        public string Name { get; set; }
        public  List<Message> Messages { get; set; } = new List<Message>();
        public  List<Image> Images { get; set; } = new List<Image>();
        public  List<AppUser> Users { get; set; } = new List<AppUser>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chat, ChatVm>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Messages, opt => opt.MapFrom(x => x.Messages))
                .ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images))
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users));
        }
    }
}
