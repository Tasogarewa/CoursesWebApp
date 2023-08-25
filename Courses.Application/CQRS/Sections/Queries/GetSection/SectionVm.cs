using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSection
{
    public class SectionVm:IMapWith<Section>
    {
        public string Name { get; set; }
        public virtual List<Lection> Lections { get; set; } = new List<Lection>();
        public virtual Course Course { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Section, SectionVm>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Course, opt => opt.MapFrom(x => x.Course))
                .ForMember(x => x.Lections, opt => opt.MapFrom(x => x.Lections));
        }
    }
}
