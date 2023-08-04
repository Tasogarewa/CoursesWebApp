using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotification
{
    public class GetNotificationQueryValidator:AbstractValidator<GetNotificationQuery>
    {
        public GetNotificationQueryValidator() 
        {
            RuleFor(notification => notification.Id).NotEqual(Guid.Empty);
            RuleFor(notification => notification.UserId).NotEqual(Guid.Empty);
        }
    }
}
