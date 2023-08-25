using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.CQRS.Mentors.Queries.GetMentor;

namespace Tasogarewa.Application.CQRS.Mentors.Queries.GetMentors
{
    public class GetMentorsQueryValidator:AbstractValidator<GetMentorQuery>
    {
        public GetMentorsQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
