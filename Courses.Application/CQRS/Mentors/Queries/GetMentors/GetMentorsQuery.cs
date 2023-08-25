using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Mentors.Queries.GetMentors
{
    public class GetMentorsQuery:IRequest<MentorListVm>
    {
    }
}
