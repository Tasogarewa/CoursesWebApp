using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.Lections.Queries.GetLection;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLections
{
    public class LectionDto:IMapWith<Lection>
    {
        public string Name { get; set; }
        public string Description { get; set; }
     
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lection, LectionVm>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description));
             
        }
    }
}
