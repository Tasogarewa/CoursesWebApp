using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserArchivedCourses.Queries.GetArchivedCourses
{
    public class ArchivedCoursesVm:IMapWith<ArchivedCourses>
    {
        public Guid Id { get; set; }
        public List<ArchivedCourse> Courses { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ArchivedCourses, ArchivedCoursesVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Courses, opt => opt.MapFrom(x => x.Courses));
                
        }
    }
}
