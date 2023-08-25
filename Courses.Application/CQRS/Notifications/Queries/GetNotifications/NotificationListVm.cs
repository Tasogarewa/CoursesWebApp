using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications
{
    public class NotificationListVm
    {
        public List<NotificationDto> NotificationsList { get; set; }
    }
}
