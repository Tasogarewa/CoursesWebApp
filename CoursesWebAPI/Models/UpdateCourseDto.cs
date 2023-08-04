using AutoMapper;
using Courses.Domain;
using System.ComponentModel.DataAnnotations;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse;
using Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse;

namespace CoursesWebAPI.Models
{
    public class UpdateCourseDto:IMapWith<UpdateCourseCommand>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Expires { get; set; }
        [MinLength(4)]
        [MaxLength(30)]
        public string Name { get; set; }
        [MinLength(300)]
        [MaxLength(2000)]
        public string Description { get; set; }
        public string FilePath { get; set; }
        public ICollection<Image> Images { get; set; } = new List<Image>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseDto,UpdateCourseCommand>().ForMember(x => x.Expires, opt => opt.MapFrom(x => x.Expires)).
                ForMember(x => x.FilePath, opt => opt.MapFrom(x => x.FilePath)).
                ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price)).
                ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name)).
                ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images)).
                ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description)).
                ForMember(x=>x.Id,opt=>opt.MapFrom(x=>x.Id));

        }
    }
}
