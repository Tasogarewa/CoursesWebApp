using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;

namespace Tasogarewa.Application.CQRS.Messages.Queries.GetMessages
{
    public class MessagesDto:IMapWith<Message>
    {
        public Guid Id { get; set; }
        public  AppUser AppUser { get; set; }
        public DateTime Sended { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        public Chat Chat { get; set; }
        public  ICollection<Image> Images { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessagesDto>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                ForMember(x => x.AppUser, opt => opt.MapFrom(x => x.AppUser)).
                ForMember(x => x.Sended, opt => opt.MapFrom(x => x.Sended)).
                ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text)).
                ForMember(x => x.Images, opt => opt.MapFrom(x => x.Images)).
                ForMember(x=>x.Chat,opt=>opt.MapFrom(x=>x.Chat));
        }
    }
}
