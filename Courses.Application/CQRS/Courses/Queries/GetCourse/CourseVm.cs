using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourse
{
    public  class CourseVm:IMapWith<Course>
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public decimal Price { get; set; }
        public DateTime Expires { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  AppUser appUser { get; set; }
        public string FilePath { get; set; }
        public  ICollection<Image> Images { get; set; } = new List<Image>();
        public int Rating { get; set; }
        public  ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseVm>().ForMember(x => x.Expires, opt => opt.MapFrom(x => x.Expires)).
                ForMember(x => x.FilePath, opt => opt.MapFrom(x => x.FilePath)).
                ForMember(x => x.appUser, opt => opt.MapFrom(x => x.appUser)).
                ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments)).
                ForMember(x => x.CreateAt, opt => opt.MapFrom(x => x.CreateAt)).
                ForMember(x => x.UpdateAt, opt => opt.MapFrom(x => x.UpdateAt)).
                ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description)).
                ForMember(x => x.Price, opt => opt.MapFrom(x => x.Description)).
                ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating)).
                ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images)).
                ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

        }
    }
}
