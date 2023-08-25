using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Lections.Queries.GetLection
{
    public class LectionVm:IMapWith<Lection>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public virtual Test Tests { get; set; }
        public virtual CodeEx CodeEx { get; set; }
        public virtual Section Section { get; set; }
        public virtual List<LectionNotice> LectionNotices { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lection, LectionVm>()
                .ForMember(x => x.FilePath, opt => opt.MapFrom(x => x.FilePath))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.Tests, opt => opt.MapFrom(x => x.Tests))
                .ForMember(x => x.CodeEx, opt => opt.MapFrom(x => x.CodeEx))
                .ForMember(x => x.Section, opt => opt.MapFrom(x => x.Section))
                .ForMember(x => x.LectionNotices, opt => opt.MapFrom(x => x.LectionNotices));

        }
    }
}
