using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments
{
    public class AnnouncmentDto:IMapWith<Announcement>
    {
        public Mentor Mentor { get; set; }
        public string Text { get; set; }
        public List<Image> Images { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public List<Comment> Comments { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Announcement, AnnouncmentDto>()
                .ForMember(x=>x.Mentor,opt=>opt.MapFrom(x=>x.Mentor))
                .ForMember(x=>x.CreateAt,opt=>opt.MapFrom(x=>x.CreateAt))
                .ForMember(x=>x.UpdateAt,opt=>opt.MapFrom(x=>x.UpdateAt))
                .ForMember(x=>x.Comments,opt=>opt.MapFrom(x=>x.Comments))
                .ForMember(x=>x.Images,opt=>opt.MapFrom(x=>x.Images))
                .ForMember(x=>x.Text,opt=>opt.MapFrom(x=>x.Text));
        }
    }   
}
