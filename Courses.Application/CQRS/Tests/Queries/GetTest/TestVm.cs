using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Tests.Queries.GetTest
{
    public class TestVm:IMapWith<Test>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Lection Lection { get; set; }
        public virtual List<Question> Questions { get; set; } = new List<Question>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Test, TestVm>()
                .ForMember(x => x.Questions, opt => opt.MapFrom(x => x.Questions))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Lection, opt => opt.MapFrom(x => x.Lection))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}
