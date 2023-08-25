using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserChats.Queries.GetChats
{
    public class GetChatsQueryValidator:AbstractValidator<GetChatsQuery>
    {
        public GetChatsQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
