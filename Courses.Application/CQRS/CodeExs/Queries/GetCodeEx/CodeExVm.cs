using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CodeExs.Queries.GetCodeEx
{
    public class CodeExVm:IMapWith<CodeEx>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Hint { get; set; }
        public string Solution { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CodeEx, CodeExVm>()
                .ForMember(x=>x.Name,opt=>opt.MapFrom(x=>x.Name))
                  .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                    .ForMember(x => x.Hint, opt => opt.MapFrom(x => x.Hint))
                       .ForMember(x => x.Solution, opt => opt.MapFrom(x => x.Solution))
                          .ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images));
        }
    }
}
