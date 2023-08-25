using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.LectionNotices.Queries.GetLectionNotices
{
    public class GetLectionNoticesQueryValidator:AbstractValidator<GetLectionNoticesQuery>
    {
        public GetLectionNoticesQueryValidator() 
        {
            RuleFor(x => x.LectionId).NotEqual(Guid.Empty);
        }
    }
}
