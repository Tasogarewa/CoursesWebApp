using AutoMapper;
using Courses.Domain;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.Chats.Commands.CreateChat;
using Tasogarewa.Application.CQRS.Images.Commands.CreateImage;

namespace CoursesWebAPI.Models
{
    public class CreateImageDto: IMapWith<CreateImageCommand>
    {

        public string Path { get; set; }
        public  Course? Course { get; set; }
        public AppUser appUser { get; set; }
        public void Mapping(Profile profile)
            {
            profile.CreateMap<CreateImageDto, CreateImageCommand>().ForMember(x => x.Path, opt => opt.MapFrom(x => x.Path)).
            ForMember(x => x.CourseId, opt => opt.MapFrom(x => x.Course.Id)).
            ForMember(x=>x.UserId,opt=>opt.MapFrom(x=>x.appUser.Id));
            
            }
        
    }
}
