using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices
{
    public class LectionNoticeDto:IMapWith<LectionNotice>
    {
        public virtual AppUser User { get; set; }
        public TimeSpan From { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Text { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LectionNotice, LectionNoticeDto>()
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                 .ForMember(x => x.From, opt => opt.MapFrom(x => x.From))
                  .ForMember(x => x.CreateAt, opt => opt.MapFrom(x => x.CreateAt))
                   .ForMember(x => x.UpdateAt, opt => opt.MapFrom(x => x.UpdateAt))
                    .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text));

        }
    }
}
