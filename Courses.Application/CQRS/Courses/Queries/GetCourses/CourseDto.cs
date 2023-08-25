using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourses
{
    public class CourseDto:IMapWith<Course>
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public Mentor Mentor { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public int Rating { get; set; }
        public int Views { get; set; }
        public string Goals { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseVm>()
               .ForMember(x => x.CreateAt, opt => opt.MapFrom(x => x.CreateAt))
                 .ForMember(x => x.UpdateAt, opt => opt.MapFrom(x => x.UpdateAt))
                   .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
                     .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                       .ForMember(x => x.Mentor, opt => opt.MapFrom(x => x.Mentor))
                         .ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images))
                           .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating))
                             .ForMember(x => x.Views, opt => opt.MapFrom(x => x.Views))
                               .ForMember(x => x.Goals, opt => opt.MapFrom(x => x.Goals));

        }
    }
}
