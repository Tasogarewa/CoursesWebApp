using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AppUsers.Queries.GetAppUser
{
    public class GetAppUserQueryValidator:AbstractValidator<GetAppUserQuery>
    {
        public GetAppUserQueryValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
