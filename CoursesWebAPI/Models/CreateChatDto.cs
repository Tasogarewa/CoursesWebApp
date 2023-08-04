using AutoMapper;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.Chats.Commands.CreateChat;

namespace CoursesWebAPI.Models
{
    public class CreateChatDto:IMapWith<CreateChatCommand>
    {
        public  ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateChatDto, CreateChatCommand>().ForMember(x=>x.Users,opt=>opt.MapFrom(x=>x.AppUsers));
        }
    }
}
