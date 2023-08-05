using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChats
{
    public class GetChatsQueryValidator:AbstractValidator<GetChatsQuery>
    {
       public GetChatsQueryValidator()
        {
            RuleFor(chat => chat.UserId).NotEqual(Guid.Empty);
        }
    }
}
