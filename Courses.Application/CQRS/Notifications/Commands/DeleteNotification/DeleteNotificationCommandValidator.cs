using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommandValidator:AbstractValidator<DeleteNotificationCommand>
    {
        public DeleteNotificationCommandValidator() 
        {
            RuleFor(notification => notification.Id).NotEqual(Guid.Empty);
        }
    }
}
