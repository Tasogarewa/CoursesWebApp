using AutoMapper;
using Courses.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.CQRS.Notifications.Queries.GetNotification;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications
{
    public class NotificationDto : IMapWith<Notification>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Create { get; set; }
        public Image Image { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notification, NotificationDto>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
                ForMember(x => x.Text, opt => opt.MapFrom(x => x.Text)).
                ForMember(x => x.Create, opt => opt.MapFrom(x => x.Create)).
                ForMember(x => x.Image, opt => opt.MapFrom(x => x.Image));
        }
    }
}

