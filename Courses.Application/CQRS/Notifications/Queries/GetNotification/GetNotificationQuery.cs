using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotification
{
    public class GetNotificationQuery:IRequest<NotificationVm>
    {
        public Guid Id { get; set; }
        
    }
}
