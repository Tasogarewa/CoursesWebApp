using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourse
{
    public  class CourseVm:IMapWith<Course>
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public decimal Price { get; set; }
        public int Views { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Goals { get; set; }
        public string Requierments { get; set; }
        public  CourseChat Chat { get; set; }
        public List<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
        public List<Announcement> Announcements { get; set; } = new List<Announcement>();
        public List<Section> Sections { get; set; } = new List<Section>();
        public  Mentor Mentor { get; set; }
        public List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        public  List<Image> Images { get; set; } = new List<Image>();
        public int Rating { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseVm>()
                .ForMember(x => x.CreateAt, opt => opt.MapFrom(x => x.CreateAt))
                 .ForMember(x => x.UpdateAt, opt => opt.MapFrom(x => x.UpdateAt))
                  .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
                   .ForMember(x => x.Views, opt => opt.MapFrom(x => x.Views))
                    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                     .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                      .ForMember(x => x.Goals, opt => opt.MapFrom(x => x.Goals))
                       .ForMember(x => x.Requierments, opt => opt.MapFrom(x => x.Requierments))
                        .ForMember(x => x.Chat, opt => opt.MapFrom(x => x.Chat))
                         .ForMember(x => x.CourseTags, opt => opt.MapFrom(x => x.CourseTags))
                          .ForMember(x => x.Announcements, opt => opt.MapFrom(x => x.Announcements))
                           .ForMember(x => x.Sections, opt => opt.MapFrom(x => x.Sections))
                            .ForMember(x => x.Mentor, opt => opt.MapFrom(x => x.Mentor))
                             .ForMember(x => x.CourseStudents, opt => opt.MapFrom(x => x.CourseStudents))
                              .ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images))
                               .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating))
                                .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments));



        }
    }
}
