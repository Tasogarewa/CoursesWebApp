using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChats
{
    public class ChatsDto:IMapWith<Chat>
    {
        public Guid Id { get; set; }
        public  ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Chat, ChatsDto>().
                ForMember(x => x.Id, opt => opt.MapFrom(chat => chat.Id)).
                ForMember(x => x.AppUsers, opt => opt.MapFrom(chat => chat.AppUsers));

        }
    }
}
