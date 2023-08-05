using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChat
{
    public class ChatVm:IMapWith<Chat>
    {
        public Guid Id { get; set; }
        public  ICollection<Message> Messages { get; set; } = new List<Message>();
        public  ICollection<Image> Images { get; set; } = new List<Image>();
        public  ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chat, ChatVm>().ForMember(x=>x.Id,opt=>opt.MapFrom(chat=>chat.Id)).
                ForMember(x=>x.Messages,opt=>opt.MapFrom(chat=>chat.Messages)).
                ForMember(x=>x.Images,opt=>opt.MapFrom(chat=>chat.Images)).
                ForMember(x=>x.AppUsers,opt=>opt.MapFrom(chat=>chat.AppUsers));
        }
    }
}
