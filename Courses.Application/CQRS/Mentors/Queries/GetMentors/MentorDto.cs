using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Mentors.Queries.GetMentors
{
    public class MentorDto:IMapWith<Mentor>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public virtual Image? Image { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<CourseStudent>? Students { get; set; } = new List<CourseStudent>();
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mentor, MentorDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                  .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.Surname))
                    .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                      .ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating))
                        .ForMember(x => x.Students, opt => opt.MapFrom(x => x.Students))
                          .ForMember(x => x.Courses, opt => opt.MapFrom(x => x.Courses))
                            .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Image));
        }
    }
}
