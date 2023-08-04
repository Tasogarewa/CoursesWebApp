using AutoMapper;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.Images.Commands.UpdateImage;

namespace CoursesWebAPI.Models
{
    public class UpdateImageDto:IMapWith<UpdateImageCommand>
    {
        public string Path { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateImageDto, UpdateImageCommand>().ForMember(x => x.Path, opt => opt.MapFrom(x => x.Path));
        }
    }
}
