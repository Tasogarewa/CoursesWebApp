using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;

namespace Tasogarewa.Application.CQRS.Comments.Queries.GetComments
{
    public class CommentsDto:IMapWith<Comment>
    {
        public Guid Id { get; set;}
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        public  AppUser appUser { get; set; }
        public string Replay { get; set; }
        public  Course Course { get; set; }
        public int Rating { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentsDto>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                ForMember(x => x.Update, opt => opt.MapFrom(x => x.Update)).
                ForMember(x => x.appUser, opt => opt.MapFrom(x => x.appUser)).
                ForMember(x => x.Create, opt => opt.MapFrom(x => x.Create)).
                ForMember(x => x.Rating, opt => opt.MapFrom(x => x.Rating)).
                ForMember(x => x.Replay, opt => opt.MapFrom(x => x.Replay)).
                ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text));
        }
    }
}
