using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Notifications.Queries.GetNotifications
{
    public class GetNotificationsQueryValidator:AbstractValidator<GetNotificationsQuery>
    {
        public GetNotificationsQueryValidator() 
        {
            RuleFor(notification => notification.UserId).NotEqual(Guid.Empty);
        }
    }
}
