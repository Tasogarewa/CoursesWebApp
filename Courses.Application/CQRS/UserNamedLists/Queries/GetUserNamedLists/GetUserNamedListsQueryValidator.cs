using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedLists
{
    public class GetUserNamedListsQueryValidator:AbstractValidator<GetUserNamedListsQuery>
    {
        public GetUserNamedListsQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
