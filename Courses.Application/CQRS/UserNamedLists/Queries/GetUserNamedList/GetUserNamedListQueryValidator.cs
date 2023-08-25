using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Queries.GetUserNamedList
{
    public class GetUserNamedListQueryValidator:AbstractValidator<GetUserNamedListQuery>
    {
        public GetUserNamedListQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
