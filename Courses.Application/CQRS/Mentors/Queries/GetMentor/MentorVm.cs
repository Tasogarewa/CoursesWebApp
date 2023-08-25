using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Mentors.Queries.GetMentor
{
    public class MentorVm:IMapWith<Mentor>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public virtual Image? Image { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<CourseStudent>? Students { get; set; } = new List<CourseStudent>();
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
        public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Web { get; set; }
        public string? YouTube { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? GitHub { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mentor, MentorVm>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                 .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.Surname))
                  .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                   .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Image))
                    .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating))
                     .ForMember(x => x.Students, opt => opt.MapFrom(x => x.Students))
                      .ForMember(x => x.Courses, opt => opt.MapFrom(x => x.Courses))
                       .ForMember(x => x.Reviews, opt => opt.MapFrom(x => x.Reviews))
                        .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments))
                         .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                          .ForMember(x => x.Phone, opt => opt.MapFrom(x => x.Phone))
                           .ForMember(x => x.Web, opt => opt.MapFrom(x => x.Web))
                            .ForMember(x => x.YouTube, opt => opt.MapFrom(x => x.YouTube))
                             .ForMember(x => x.Twitter, opt => opt.MapFrom(x => x.Twitter))
                              .ForMember(x => x.Facebook, opt => opt.MapFrom(x => x.Facebook))
                               .ForMember(x => x.Instagram, opt => opt.MapFrom(x => x.Instagram))
                                .ForMember(x => x.GitHub, opt => opt.MapFrom(x => x.GitHub));

        }
    }
}
