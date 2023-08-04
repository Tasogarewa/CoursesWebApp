using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Messages.Queries.GetMessages
{
    public class GetMessagesQueryValidator:AbstractValidator<GetMessagesQuery>
    {
        public GetMessagesQueryValidator() 
        {
            RuleFor(message => message.ChatId).NotEqual(Guid.Empty);
        }
    }
}
