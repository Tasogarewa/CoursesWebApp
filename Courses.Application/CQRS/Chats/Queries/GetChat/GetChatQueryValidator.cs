using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChat
{
    public class GetChatQueryValidator:AbstractValidator<GetChatQuery>
    {
        public GetChatQueryValidator() 
        {
            RuleFor(chat => chat.UserId).NotEqual(Guid.Empty);
            RuleFor(chat => chat.Id).NotEqual(Guid.Empty);

        }
    }
}
