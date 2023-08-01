using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.CQRS.Images.Queries.GetImages;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications
{
    public class NotificationListVm
    {
        public List<NotificationDto> NotificationsList { get; set; }
    }
}
